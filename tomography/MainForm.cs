using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace tomography
{
    public partial class MainForm : Form
    {
        private Bitmap _initImage;
        private Tomography _tomography;
        private const int Size = 256;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void OnLoadMainForm(object sender, EventArgs e)
        {
            trackBar_rotate.Maximum = Size - 1;
            //OnClickButtonLoadImage(null, null);
        }

        private void OnClickButtonLoadImage(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files(*.BMP;*.PNG;*.JPG)|*.BMP;*.PNG;*.JPG|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _initImage = new Bitmap(dialog.FileName);
                    _tomography = new Tomography(_initImage, Size, Size, Size);
                    pB_initImage.Image = _tomography.RotatedMatrixList[0].GetBitmap();
                    pB_intensity.Image = _tomography.IntensityMatrix.GetBitmap();
                    pB_fftIntensity.Image = _tomography.FftMatrix.GetBitmap();
                    pB_spectrum.Image = _tomography.RotatedFftMatrix.GetBitmap();
                    pB_restoredImage.Image = _tomography.RestoredMatrix.GetBitmap();
                    //pB_restoredImage.Image = _tomography.RestoredImage;
                    chart_intensity.Series[0].Points.Clear();
                    for (var i = 0; i < Size; i++)
                    {
                        var max = _tomography.IntensityMatrix.Matrix[0].Max(j => j.Magnitude);
                        chart_intensity.Series[0].Points.AddXY(_tomography.IntensityMatrix.Matrix[0][Size - 1 - i].Magnitude / max, i);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка!");
                }
            }
        }

        private void OnScrollTrackBarRotate(object sender, EventArgs e)
        {
            var tbValue = trackBar_rotate.Value;
            pB_initImage.Image = _tomography.RotatedMatrixList[tbValue].GetBitmap();
            chart_intensity.Series[0].Points.Clear();
            for (var i = 0; i < _tomography.IntensityMatrix.Height; i++)
            {
                var max = _tomography.IntensityMatrix.Matrix[tbValue].Max(j => j.Magnitude);
                chart_intensity.Series[0].Points.AddXY(_tomography.IntensityMatrix.Matrix[tbValue][Size - 1 - i].Magnitude / max, i);
            }
        }
    }
}