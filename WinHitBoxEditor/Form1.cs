using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using Serilog.Core;

namespace WinHitBoxEditor
{
    public partial class Form1 : Form
    {
        public Item CurrentItem;
        public Color PaintColor;
        public SolidBrush semiTransparentBrush;
        public List<RectangleF> rectangles;

        public float ImageHeight { get; set; }
        public float ImageWidth { get; set; }
        public bool CanImageFit { get; set; }
        public bool IsDown { get; set; }
        public bool IsSelected { get; set; }
        public int SelectedRectangle { get; set; }
        public int OriginX { get; set; }
        public int OriginY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }

        public Form1()
        {

            InitializeComponent();
            rectangles = new List<RectangleF>();
            PaintColor = Color.FromArgb(128, 10, 10, 100);
            semiTransparentBrush = new SolidBrush(PaintColor);
            imagePane.MouseWheel += ImagePane_MouseWheel;

        //--------------Logger--------------------------//
            Log.Logger = new LoggerConfiguration().
                MinimumLevel.Debug().
                WriteTo.Console()
                .WriteTo.File(@"F:\\C# Stuff\\HitBoxWinformRepo\\HitBoxEditor\\WinHitBoxEditor\\Logging\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        //--------------Logger--------------------------//


        }

        private void ImagePane_MouseWheel(object sender, MouseEventArgs e)
        {
            Log.Debug("Delta: " + e.Delta);

            Graphics graphics = imagePane.CreateGraphics();
            if(e.Delta > 0 && imagePane.Image != null)
            {
                Scale(graphics, 1.3f);
            }
            else
            {
                Scale(graphics, .75f);
            }
            graphics.Dispose();
        }

        private void Scale(Graphics graphics, float scale)
        {
            graphics.Clear(imagePane.BackColor);
            //graphics.DrawImage(imagePane.Image, new Point(0, 0));
            RectangleF destinationRect = new RectangleF(
                0,
                0,
               ImageWidth,
                ImageHeight);
            RectangleF sourceRect = new RectangleF(0, 0,
                    scale *imagePane.Image.Width,
                    scale * imagePane.Image.Height);
            graphics.DrawImage(
                imagePane.Image,
                destinationRect,
                sourceRect,
                GraphicsUnit.Pixel);

            ImageWidth *= scale;
            ImageHeight *= scale;
        }

        public enum Item
        {
            Resize, Move, Rectangle
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All supported graphics | *.jpg; *.jpeg; *.png";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                imagePane.Image = new Bitmap(openFile.FileName);
                ImageWidth = imagePane.Image.Width;
                ImageHeight = imagePane.Image.Height;

                CanImageFit = (imagePane.Image.Width < imagePane.Width && imagePane.Image.Height < imagePane.Height);
                if (CanImageFit)
                    imagePane.SizeMode = PictureBoxSizeMode.CenterImage;
                else
                    imagePane.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            CurrentItem = Item.Resize;
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            CurrentItem = Item.Move;
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            CurrentItem = Item.Rectangle;
        }

        private void imagePane_MouseDown(object sender, MouseEventArgs e)
        {
            IsDown = true;
            OriginX = e.X;
            OriginY = e.Y;
            var count = 0;
            for (int i = 0; i < rectangles.Count; i++)
            {
                if (rectangles[i].Contains(e.Location))
                {

                    SelectedRectangle = i;
                    Log.Debug("Selected Rectangle Index: " + SelectedRectangle);
                    RectangleLabel.Text = "Rectangle: X: " +
                        rectangles[SelectedRectangle].X +
                        " Y: " + rectangles[SelectedRectangle].Y +
                        " Width: " + rectangles[SelectedRectangle].Width
                        + " Height: " + rectangles[SelectedRectangle].Height;
                    IsSelected = true;
                    count++;


                }

            }
            if (count == 0)
            {
                Log.Debug("Not selected");
                IsSelected = false;
            }

            if (CurrentItem == Item.Resize)
            {

            }

        }

        private void imagePane_MouseMove(object sender, MouseEventArgs e)
        {

            if (IsDown)
            {
                Graphics graphics = imagePane.CreateGraphics();
                switch (CurrentItem)
                {
                    case Item.Rectangle:
                        this.Refresh();
                        foreach (var rectangle in rectangles)
                        {
                            graphics.FillRectangle(semiTransparentBrush, rectangle);
                        }
                        var rect = new Rectangle(OriginX, OriginY, e.X - OriginX, e.Y - OriginY);
                        graphics.FillRectangle(semiTransparentBrush, rect);

                        break;
                    case Item.Move:
                        if (IsSelected)
                        {
                            var newRect = rectangles[SelectedRectangle];
                            newRect.X = e.X;
                            newRect.Y = e.Y;
                            rectangles[SelectedRectangle] = newRect;
                            this.Refresh();//RefreshCanvas(graphics);
                            Log.Debug("Selected Rectangle Index: " + SelectedRectangle);
                            foreach (var rectangle in rectangles)
                            {
                                graphics.FillRectangle(semiTransparentBrush, rectangle);
                            }
                        }
                        else
                        {
                            int deltaX = e.X - OriginX;
                            int deltaY = e.Y - OriginY;
                            int newX = imagePane.Location.X + deltaX;
                            int newY = imagePane.Location.Y + deltaY;
                            imagePane.Location = new Point(newX, newY);
                        }
                        break;

                }

                graphics.Dispose();
            }

        }

        private void imagePane_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsDown)
            {
                EndX = e.X;
                EndY = e.Y;
                IsDown = false;

                Graphics graphics = imagePane.CreateGraphics();

                switch (CurrentItem)
                {
                    case Item.Rectangle:
                        rectangles.Add(new Rectangle(OriginX, OriginY, EndX - OriginX, EndY - OriginY));
                        this.Refresh();//RefreshCanvas(graphics);
                        foreach (var rectangle in rectangles)
                        {
                            graphics.FillRectangle(semiTransparentBrush, rectangle);
                        }
                        break;
                    case Item.Move:
                        break;
                }

                graphics.Dispose();
            }
        }

        private void RefreshCanvas(Graphics graphics)
        {
            graphics.Clear(imagePane.BackColor);
            if (imagePane.Image != null)
            {
                if (!CanImageFit)
                    graphics.DrawImage(imagePane.Image, new Rectangle(0, 0, imagePane.Width, imagePane.Height));
                else
                    graphics.DrawImage(imagePane.Image, new Rectangle(imagePane.Width / 2, imagePane.Height / 2, imagePane.Width, imagePane.Height));
            }
            Console.WriteLine(rectangles.Count);
            foreach (var rectangle in rectangles)
            {
                graphics.FillRectangle(semiTransparentBrush, rectangle);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.CloseAndFlush();
        }

        private void imagePane_MouseHover(object sender, EventArgs e)
        {
            imagePane.Focus();
        }
    }
}
