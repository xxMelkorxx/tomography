using System;
using System.Drawing;
using System.Windows.Forms;

namespace tomography
{
    public partial class MainForm : Form
    {
        private Bitmap _initImage;
        private Tomography _tomography;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void OnLoadMainForm(object sender, EventArgs e)
        {
            //OnClickButtonLoadImage(null, null);
        }

        private void OnClickButtonLoadImage(object sender, EventArgs e)
        {
            var size = 256;
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files(*.BMP;*.PNG;*.JPG)|*.BMP;*.PNG;*.JPG|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _initImage = new Bitmap(dialog.FileName);
                    _tomography = new Tomography(_initImage, size, size, size);
                    pB_initImage.Image = _tomography.InitImage;
                    pB_intensity.Image = _tomography.IntensityMatrix.GetBitmap();
                    pB_fftIntensity.Image = _tomography.FftMatrix.GetBitmap();
                    pB_spectrum.Image = _tomography.RotatedFftMatrix.GetBitmap();
                    pB_restoredImage.Image = _tomography.RestoredMatrix.GetBitmap();
                    pB_restoredImage.Image = _tomography.RestoredImage;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка!");
                }
            }
        }
    }
}