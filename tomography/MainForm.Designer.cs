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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.pB_initImage = new System.Windows.Forms.PictureBox();
			this.pB_spectrum = new System.Windows.Forms.PictureBox();
			this.pB_restoredImage = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.pB_intensity = new System.Windows.Forms.PictureBox();
			this.pB_fftIntensity = new System.Windows.Forms.PictureBox();
			this.trackBar_rotate = new System.Windows.Forms.TrackBar();
			this.chart_intensity = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.pB_initImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pB_spectrum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pB_restoredImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pB_intensity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pB_fftIntensity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_rotate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart_intensity)).BeginInit();
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
			this.pB_spectrum.Location = new System.Drawing.Point(624, 418);
			this.pB_spectrum.Name = "pB_spectrum";
			this.pB_spectrum.Size = new System.Drawing.Size(400, 400);
			this.pB_spectrum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pB_spectrum.TabIndex = 1;
			this.pB_spectrum.TabStop = false;
			// 
			// pB_restoredImage
			// 
			this.pB_restoredImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pB_restoredImage.Location = new System.Drawing.Point(624, 12);
			this.pB_restoredImage.Name = "pB_restoredImage";
			this.pB_restoredImage.Size = new System.Drawing.Size(400, 400);
			this.pB_restoredImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pB_restoredImage.TabIndex = 2;
			this.pB_restoredImage.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 788);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(606, 30);
			this.button1.TabIndex = 3;
			this.button1.Text = "Загрузить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnClickButtonLoadImage);
			// 
			// pB_intensity
			// 
			this.pB_intensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pB_intensity.Location = new System.Drawing.Point(12, 482);
			this.pB_intensity.Name = "pB_intensity";
			this.pB_intensity.Size = new System.Drawing.Size(300, 300);
			this.pB_intensity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pB_intensity.TabIndex = 4;
			this.pB_intensity.TabStop = false;
			// 
			// pB_fftIntensity
			// 
			this.pB_fftIntensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pB_fftIntensity.Location = new System.Drawing.Point(318, 482);
			this.pB_fftIntensity.Name = "pB_fftIntensity";
			this.pB_fftIntensity.Size = new System.Drawing.Size(300, 300);
			this.pB_fftIntensity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pB_fftIntensity.TabIndex = 5;
			this.pB_fftIntensity.TabStop = false;
			// 
			// trackBar_rotate
			// 
			this.trackBar_rotate.Location = new System.Drawing.Point(12, 418);
			this.trackBar_rotate.Name = "trackBar_rotate";
			this.trackBar_rotate.Size = new System.Drawing.Size(606, 45);
			this.trackBar_rotate.TabIndex = 6;
			this.trackBar_rotate.Scroll += new System.EventHandler(this.OnScrollTrackBarRotate);
			// 
			// chart_intensity
			// 
			this.chart_intensity.BorderlineColor = System.Drawing.Color.DimGray;
			this.chart_intensity.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
			chartArea2.AxisX.Maximum = 1D;
			chartArea2.AxisX.Minimum = 0D;
			chartArea2.AxisX.TitleFont = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			chartArea2.AxisX2.TitleFont = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
			chartArea2.AxisY.TitleFont = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			chartArea2.AxisY2.TitleFont = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			chartArea2.Name = "ChartArea1";
			this.chart_intensity.ChartAreas.Add(chartArea2);
			legend2.DockedToChartArea = "ChartArea1";
			legend2.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			legend2.IsTextAutoFit = false;
			legend2.Name = "Legend1";
			legend2.TitleFont = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.chart_intensity.Legends.Add(legend2);
			this.chart_intensity.Location = new System.Drawing.Point(418, 12);
			this.chart_intensity.Name = "chart_intensity";
			this.chart_intensity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			series2.Legend = "Legend1";
			series2.LegendText = "Интесивность";
			series2.Name = "Intensity";
			this.chart_intensity.Series.Add(series2);
			this.chart_intensity.Size = new System.Drawing.Size(200, 400);
			this.chart_intensity.TabIndex = 7;
			this.chart_intensity.Text = "chart1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(1036, 826);
			this.Controls.Add(this.chart_intensity);
			this.Controls.Add(this.trackBar_rotate);
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
			((System.ComponentModel.ISupportInitialize)(this.trackBar_rotate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart_intensity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.PictureBox pB_initImage;
        private System.Windows.Forms.PictureBox pB_spectrum;
        private System.Windows.Forms.PictureBox pB_restoredImage;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pB_intensity;
		private System.Windows.Forms.PictureBox pB_fftIntensity;
        private System.Windows.Forms.TrackBar trackBar_rotate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_intensity;
    }
}

