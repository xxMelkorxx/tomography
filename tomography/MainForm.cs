using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tomography
{
    public partial class MainForm : Form
    {
        private Bitmap _initImage; 

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void OnLoadMainForm(object sender, EventArgs e)
        {
            OnClickButtonLoadImage(null, null);
            var rotateImage = Tomography.RotateImage(_initImage, 10);
            pB_initImage.Image = _initImage;
            pB_restoredImage.Image = rotateImage;
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
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка!");
                }
            }
        }
    }
}