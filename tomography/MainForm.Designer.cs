namespace tomography
{
  partial class MainForm
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
			this.pB_initImage = new System.Windows.Forms.PictureBox();
			this.pB_spectrum = new System.Windows.Forms.PictureBox();
			this.pB_restoredImage = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.pB_intensity = new System.Windows.Forms.PictureBox();
			this.pB_fftIntensity = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pB_initImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pB_spectrum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pB_restoredImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pB_intensity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pB_fftIntensity)).BeginInit();
			this.SuspendLayout();
			// 
			// pB_initImage
			// 
			this.pB_initImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pB_initImage.Location = new System.Drawing.Point(12, 12);
			this.pB_initImage.Name = "pB_initImage";
			this.pB_initImage.Size = new System.Drawing.Size(400, 400);
			this.pB_initImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pB_initImage.TabIndex = 0;
			this.pB_initImage.TabStop = false;
			// 
			// pB_spectrum
			// 
			this.pB_spectrum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pB_spectrum.Location = new System.Drawing.Point(418, 12);
			this.pB_spectrum.Name = "pB_spectrum";
			this.pB_spectrum.Size = new System.Drawing.Size(400, 400);
			this.pB_spectrum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pB_spectrum.TabIndex = 1;
			this.pB_spectrum.TabStop = false;
			// 
			// pB_restoredImage
			// 
			this.pB_restoredImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pB_restoredImage.Location = new System.Drawing.Point(824, 12);
			this.pB_restoredImage.Name = "pB_restoredImage";
			this.pB_restoredImage.Size = new System.Drawing.Size(400, 400);
			this.pB_restoredImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pB_restoredImage.TabIndex = 2;
			this.pB_restoredImage.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(824, 788);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(400, 30);
			this.button1.TabIndex = 3;
			this.button1.Text = "Загрузить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnClickButtonLoadImage);
			// 
			// pB_intensity
			// 
			this.pB_intensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pB_intensity.Location = new System.Drawing.Point(12, 418);
			this.pB_intensity.Name = "pB_intensity";
			this.pB_intensity.Size = new System.Drawing.Size(400, 400);
			this.pB_intensity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pB_intensity.TabIndex = 4;
			this.pB_intensity.TabStop = false;
			// 
			// pB_fftIntensity
			// 
			this.pB_fftIntensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pB_fftIntensity.Location = new System.Drawing.Point(418, 418);
			this.pB_fftIntensity.Name = "pB_fftIntensity";
			this.pB_fftIntensity.Size = new System.Drawing.Size(400, 400);
			this.pB_fftIntensity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pB_fftIntensity.TabIndex = 5;
			this.pB_fftIntensity.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(1234, 825);
			this.Controls.Add(this.pB_fftIntensity);
			this.Controls.Add(this.pB_intensity);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pB_restoredImage);
			this.Controls.Add(this.pB_spectrum);
			this.Controls.Add(this.pB_initImage);
			this.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "ИСИТ ННГУ | Томография";
			this.Load += new System.EventHandler(this.OnLoadMainForm);
			((System.ComponentModel.ISupportInitialize)(this.pB_initImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pB_spectrum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pB_restoredImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pB_intensity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pB_fftIntensity)).EndInit();
			this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.PictureBox pB_initImage;
        private System.Windows.Forms.PictureBox pB_spectrum;
        private System.Windows.Forms.PictureBox pB_restoredImage;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pB_intensity;
		private System.Windows.Forms.PictureBox pB_fftIntensity;
	}
}

