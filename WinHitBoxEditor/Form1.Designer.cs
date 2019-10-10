namespace WinHitBoxEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imagePane = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.moveButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePane)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagePane
            // 
            this.imagePane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePane.Location = new System.Drawing.Point(15, 47);
            this.imagePane.Name = "imagePane";
            this.imagePane.Size = new System.Drawing.Size(773, 391);
            this.imagePane.TabIndex = 0;
            this.imagePane.TabStop = false;
            this.imagePane.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imagePane_MouseDown);
            this.imagePane.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imagePane_MouseMove);
            this.imagePane.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imagePane_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.moveButton);
            this.panel1.Controls.Add(this.selectButton);
            this.panel1.Controls.Add(this.rectangleButton);
            this.panel1.Controls.Add(this.exportButton);
            this.panel1.Controls.Add(this.openButton);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 38);
            this.panel1.TabIndex = 1;
            // 
            // moveButton
            // 
            this.moveButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.moveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveButton.Location = new System.Drawing.Point(252, 3);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 32);
            this.moveButton.TabIndex = 4;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = false;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.selectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectButton.Location = new System.Drawing.Point(162, 3);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(84, 32);
            this.selectButton.TabIndex = 3;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = false;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rectangleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rectangleButton.Location = new System.Drawing.Point(333, 3);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(89, 32);
            this.rectangleButton.TabIndex = 2;
            this.rectangleButton.Text = "Rectangle";
            this.rectangleButton.UseVisualStyleBackColor = false;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Location = new System.Drawing.Point(83, 3);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(73, 32);
            this.exportButton.TabIndex = 1;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = false;
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.openButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openButton.Location = new System.Drawing.Point(3, 3);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(74, 32);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.imagePane);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagePane)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePane;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button selectButton;
    }
}

