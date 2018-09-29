namespace IceCreamStickProcessor
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colourDistributionLabel = new System.Windows.Forms.Label();
            this.erosionDilationLabel = new System.Windows.Forms.Label();
            this.blackWhiteLabel = new System.Windows.Forms.Label();
            this.colourPictureBox = new System.Windows.Forms.PictureBox();
            this.processedImageBox = new Emgu.CV.UI.ImageBox();
            this.averageBrightnessLabel = new System.Windows.Forms.Label();
            this.callibrateButton = new System.Windows.Forms.Button();
            this.spotPercentageLabel = new System.Windows.Forms.Label();
            this.colourValuesLabel = new System.Windows.Forms.Label();
            this.debugRGBLabel = new System.Windows.Forms.Label();
            this.debugCheckBox = new System.Windows.Forms.CheckBox();
            this.goodLabel = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.spotLabel = new System.Windows.Forms.Label();
            this.colourLabel = new System.Windows.Forms.Label();
            this.yTrackBar = new System.Windows.Forms.TrackBar();
            this.xTrackBar = new System.Windows.Forms.TrackBar();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.snapButton = new System.Windows.Forms.Button();
            this.blackWhiteImageBox = new Emgu.CV.UI.ImageBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.captureImageBox = new Emgu.CV.UI.ImageBox();
            this.erodeDilateSnapButton = new System.Windows.Forms.Button();
            this.bwThresholdSnapButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colourPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackWhiteImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bwThresholdSnapButton);
            this.panel1.Controls.Add(this.erodeDilateSnapButton);
            this.panel1.Controls.Add(this.colourDistributionLabel);
            this.panel1.Controls.Add(this.erosionDilationLabel);
            this.panel1.Controls.Add(this.blackWhiteLabel);
            this.panel1.Controls.Add(this.colourPictureBox);
            this.panel1.Controls.Add(this.processedImageBox);
            this.panel1.Controls.Add(this.averageBrightnessLabel);
            this.panel1.Controls.Add(this.callibrateButton);
            this.panel1.Controls.Add(this.spotPercentageLabel);
            this.panel1.Controls.Add(this.colourValuesLabel);
            this.panel1.Controls.Add(this.debugRGBLabel);
            this.panel1.Controls.Add(this.debugCheckBox);
            this.panel1.Controls.Add(this.goodLabel);
            this.panel1.Controls.Add(this.lengthLabel);
            this.panel1.Controls.Add(this.spotLabel);
            this.panel1.Controls.Add(this.colourLabel);
            this.panel1.Controls.Add(this.yTrackBar);
            this.panel1.Controls.Add(this.xTrackBar);
            this.panel1.Controls.Add(this.fileNameBox);
            this.panel1.Controls.Add(this.snapButton);
            this.panel1.Controls.Add(this.blackWhiteImageBox);
            this.panel1.Controls.Add(this.captureButton);
            this.panel1.Controls.Add(this.captureImageBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 1055);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // colourDistributionLabel
            // 
            this.colourDistributionLabel.AutoSize = true;
            this.colourDistributionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colourDistributionLabel.Location = new System.Drawing.Point(25, 727);
            this.colourDistributionLabel.Name = "colourDistributionLabel";
            this.colourDistributionLabel.Size = new System.Drawing.Size(171, 25);
            this.colourDistributionLabel.TabIndex = 24;
            this.colourDistributionLabel.Text = "Colour Distribution";
            // 
            // erosionDilationLabel
            // 
            this.erosionDilationLabel.AutoSize = true;
            this.erosionDilationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erosionDilationLabel.Location = new System.Drawing.Point(451, 728);
            this.erosionDilationLabel.Name = "erosionDilationLabel";
            this.erosionDilationLabel.Size = new System.Drawing.Size(145, 25);
            this.erosionDilationLabel.TabIndex = 23;
            this.erosionDilationLabel.Text = "Erosion/dilation";
            // 
            // blackWhiteLabel
            // 
            this.blackWhiteLabel.AutoSize = true;
            this.blackWhiteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blackWhiteLabel.Location = new System.Drawing.Point(869, 729);
            this.blackWhiteLabel.Name = "blackWhiteLabel";
            this.blackWhiteLabel.Size = new System.Drawing.Size(196, 25);
            this.blackWhiteLabel.TabIndex = 22;
            this.blackWhiteLabel.Text = "Black/white threshold";
            // 
            // colourPictureBox
            // 
            this.colourPictureBox.Location = new System.Drawing.Point(128, 759);
            this.colourPictureBox.Name = "colourPictureBox";
            this.colourPictureBox.Size = new System.Drawing.Size(309, 259);
            this.colourPictureBox.TabIndex = 21;
            this.colourPictureBox.TabStop = false;
            this.colourPictureBox.Click += new System.EventHandler(this.colourPictureBox_Click);
            // 
            // processedImageBox
            // 
            this.processedImageBox.Location = new System.Drawing.Point(456, 759);
            this.processedImageBox.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.processedImageBox.Name = "processedImageBox";
            this.processedImageBox.Size = new System.Drawing.Size(396, 259);
            this.processedImageBox.TabIndex = 20;
            this.processedImageBox.TabStop = false;
            this.processedImageBox.Click += new System.EventHandler(this.processedImageBox_Click);
            // 
            // averageBrightnessLabel
            // 
            this.averageBrightnessLabel.AutoSize = true;
            this.averageBrightnessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.averageBrightnessLabel.Location = new System.Drawing.Point(917, 373);
            this.averageBrightnessLabel.Name = "averageBrightnessLabel";
            this.averageBrightnessLabel.Size = new System.Drawing.Size(234, 29);
            this.averageBrightnessLabel.TabIndex = 19;
            this.averageBrightnessLabel.Text = "Average Brightness";
            // 
            // callibrateButton
            // 
            this.callibrateButton.Location = new System.Drawing.Point(1719, 832);
            this.callibrateButton.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.callibrateButton.Name = "callibrateButton";
            this.callibrateButton.Size = new System.Drawing.Size(193, 58);
            this.callibrateButton.TabIndex = 18;
            this.callibrateButton.Text = "Callibrate";
            this.callibrateButton.UseVisualStyleBackColor = true;
            this.callibrateButton.Visible = false;
            this.callibrateButton.Click += new System.EventHandler(this.callibrateButton_Click);
            // 
            // spotPercentageLabel
            // 
            this.spotPercentageLabel.AutoSize = true;
            this.spotPercentageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spotPercentageLabel.Location = new System.Drawing.Point(917, 325);
            this.spotPercentageLabel.Name = "spotPercentageLabel";
            this.spotPercentageLabel.Size = new System.Drawing.Size(198, 29);
            this.spotPercentageLabel.TabIndex = 17;
            this.spotPercentageLabel.Text = "Spot percentage";
            // 
            // colourValuesLabel
            // 
            this.colourValuesLabel.AutoSize = true;
            this.colourValuesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colourValuesLabel.Location = new System.Drawing.Point(917, 185);
            this.colourValuesLabel.Name = "colourValuesLabel";
            this.colourValuesLabel.Size = new System.Drawing.Size(100, 29);
            this.colourValuesLabel.TabIndex = 16;
            this.colourValuesLabel.Text = "Colours";
            // 
            // debugRGBLabel
            // 
            this.debugRGBLabel.AutoSize = true;
            this.debugRGBLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugRGBLabel.Location = new System.Drawing.Point(917, 139);
            this.debugRGBLabel.Name = "debugRGBLabel";
            this.debugRGBLabel.Size = new System.Drawing.Size(67, 29);
            this.debugRGBLabel.TabIndex = 15;
            this.debugRGBLabel.Text = "RGB";
            // 
            // debugCheckBox
            // 
            this.debugCheckBox.AutoSize = true;
            this.debugCheckBox.Location = new System.Drawing.Point(922, 98);
            this.debugCheckBox.Name = "debugCheckBox";
            this.debugCheckBox.Size = new System.Drawing.Size(111, 21);
            this.debugCheckBox.TabIndex = 14;
            this.debugCheckBox.Text = "Debug mode";
            this.debugCheckBox.UseVisualStyleBackColor = true;
            this.debugCheckBox.CheckedChanged += new System.EventHandler(this.debugCheckBox_CheckedChanged);
            // 
            // goodLabel
            // 
            this.goodLabel.AutoSize = true;
            this.goodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goodLabel.ForeColor = System.Drawing.Color.Red;
            this.goodLabel.Location = new System.Drawing.Point(929, 521);
            this.goodLabel.Name = "goodLabel";
            this.goodLabel.Size = new System.Drawing.Size(83, 48);
            this.goodLabel.TabIndex = 13;
            this.goodLabel.Text = "NG";
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lengthLabel.Location = new System.Drawing.Point(929, 668);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(104, 29);
            this.lengthLabel.TabIndex = 12;
            this.lengthLabel.Text = "Length: ";
            // 
            // spotLabel
            // 
            this.spotLabel.AutoSize = true;
            this.spotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spotLabel.Location = new System.Drawing.Point(929, 630);
            this.spotLabel.Name = "spotLabel";
            this.spotLabel.Size = new System.Drawing.Size(205, 29);
            this.spotLabel.TabIndex = 11;
            this.spotLabel.Text = "Spot percentage:";
            // 
            // colourLabel
            // 
            this.colourLabel.AutoSize = true;
            this.colourLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colourLabel.Location = new System.Drawing.Point(929, 590);
            this.colourLabel.Name = "colourLabel";
            this.colourLabel.Size = new System.Drawing.Size(101, 29);
            this.colourLabel.TabIndex = 10;
            this.colourLabel.Text = "Colour: ";
            // 
            // yTrackBar
            // 
            this.yTrackBar.Location = new System.Drawing.Point(715, 13);
            this.yTrackBar.Maximum = 1000;
            this.yTrackBar.Name = "yTrackBar";
            this.yTrackBar.Size = new System.Drawing.Size(339, 56);
            this.yTrackBar.TabIndex = 9;
            // 
            // xTrackBar
            // 
            this.xTrackBar.Location = new System.Drawing.Point(370, 13);
            this.xTrackBar.Maximum = 1000;
            this.xTrackBar.Name = "xTrackBar";
            this.xTrackBar.Size = new System.Drawing.Size(339, 56);
            this.xTrackBar.TabIndex = 8;
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(37, 29);
            this.fileNameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(89, 22);
            this.fileNameBox.TabIndex = 7;
            // 
            // snapButton
            // 
            this.snapButton.Location = new System.Drawing.Point(161, 11);
            this.snapButton.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.snapButton.Name = "snapButton";
            this.snapButton.Size = new System.Drawing.Size(193, 58);
            this.snapButton.TabIndex = 6;
            this.snapButton.Text = "Snap";
            this.snapButton.UseVisualStyleBackColor = true;
            this.snapButton.Click += new System.EventHandler(this.snapButton_Click);
            // 
            // blackWhiteImageBox
            // 
            this.blackWhiteImageBox.Location = new System.Drawing.Point(872, 759);
            this.blackWhiteImageBox.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.blackWhiteImageBox.Name = "blackWhiteImageBox";
            this.blackWhiteImageBox.Size = new System.Drawing.Size(396, 259);
            this.blackWhiteImageBox.TabIndex = 4;
            this.blackWhiteImageBox.TabStop = false;
            this.blackWhiteImageBox.Click += new System.EventHandler(this.grayscaleImageBox_Click);
            // 
            // captureButton
            // 
            this.captureButton.Location = new System.Drawing.Point(1719, 781);
            this.captureButton.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(178, 28);
            this.captureButton.TabIndex = 3;
            this.captureButton.Text = "Start Capturing";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Visible = false;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // captureImageBox
            // 
            this.captureImageBox.Location = new System.Drawing.Point(37, 97);
            this.captureImageBox.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.captureImageBox.Name = "captureImageBox";
            this.captureImageBox.Size = new System.Drawing.Size(870, 612);
            this.captureImageBox.TabIndex = 2;
            this.captureImageBox.TabStop = false;
            // 
            // erodeDilateSnapButton
            // 
            this.erodeDilateSnapButton.Location = new System.Drawing.Point(743, 726);
            this.erodeDilateSnapButton.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.erodeDilateSnapButton.Name = "erodeDilateSnapButton";
            this.erodeDilateSnapButton.Size = new System.Drawing.Size(109, 26);
            this.erodeDilateSnapButton.TabIndex = 25;
            this.erodeDilateSnapButton.Text = "Snap";
            this.erodeDilateSnapButton.UseVisualStyleBackColor = true;
            this.erodeDilateSnapButton.Click += new System.EventHandler(this.erodeDilateSnapButton_Click);
            // 
            // bwThresholdSnapButton
            // 
            this.bwThresholdSnapButton.Location = new System.Drawing.Point(1159, 726);
            this.bwThresholdSnapButton.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.bwThresholdSnapButton.Name = "bwThresholdSnapButton";
            this.bwThresholdSnapButton.Size = new System.Drawing.Size(109, 26);
            this.bwThresholdSnapButton.TabIndex = 26;
            this.bwThresholdSnapButton.Text = "Snap";
            this.bwThresholdSnapButton.UseVisualStyleBackColor = true;
            this.bwThresholdSnapButton.Click += new System.EventHandler(this.bwThresholdSnapButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "Form1";
            this.Text = "EMT mini project";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colourPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackWhiteImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Emgu.CV.UI.ImageBox captureImageBox;
        private Emgu.CV.UI.ImageBox blackWhiteImageBox;
        private System.Windows.Forms.Button snapButton;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.TrackBar yTrackBar;
        private System.Windows.Forms.TrackBar xTrackBar;
        private System.Windows.Forms.Label colourLabel;
        private System.Windows.Forms.Label spotLabel;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label goodLabel;
        private System.Windows.Forms.CheckBox debugCheckBox;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.Label debugRGBLabel;
        private System.Windows.Forms.Label colourValuesLabel;
        private System.Windows.Forms.Label spotPercentageLabel;
        private System.Windows.Forms.Button callibrateButton;
        private System.Windows.Forms.Label averageBrightnessLabel;
        private Emgu.CV.UI.ImageBox processedImageBox;
        private System.Windows.Forms.PictureBox colourPictureBox;
        private System.Windows.Forms.Label erosionDilationLabel;
        private System.Windows.Forms.Label blackWhiteLabel;
        private System.Windows.Forms.Label colourDistributionLabel;
        private System.Windows.Forms.Button bwThresholdSnapButton;
        private System.Windows.Forms.Button erodeDilateSnapButton;
    }
}

