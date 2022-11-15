using System;
using System.Drawing;

namespace tomography
{
    public class Tomography
    {
        public ComplexMatrix InitMatrix;
        public ComplexMatrix IntensityMatrix;
        public ComplexMatrix FftMatrix;
        public ComplexMatrix RotatedFftMatrix;
        public ComplexMatrix RestoredMatrix;
        public Bitmap InitImage;
        public Bitmap RestoredImage;

        private int _width;
        private int _height;
        private int _countSensor;
        private double DeltaAngle => 2 * Math.PI / _countSensor;

        public Tomography(Bitmap bitmap, int width, int height, int countSensor)
        {
            _width = width;
            _height = height;
            _countSensor = countSensor;
            
            var oldWidth = bitmap.Width;
            var oldHeight = bitmap.Height;

            InitImage = ConvertToHalftone(bitmap);
            InitMatrix = new ComplexMatrix(Interpolation.BilinearInterpolation(InitImage, width, height));
            IntensityMatrixCalculation();
            FftMatrixCalculation();
            RotatedFftMatrixCalculation();
            RestoredMatrix = Fourier.FFT_2D(RotatedFftMatrix, false);
            RestoredImage = Interpolation.BilinearInterpolation(RestoredMatrix.GetBitmap(), oldWidth, oldHeight);

        }

        private void IntensityMatrixCalculation()
        {
            IntensityMatrix = new ComplexMatrix(_countSensor, _height);
            for (var k = 0; k < _countSensor; k++)
            {
                var angle = DeltaAngle * k;
                for (var i = 0; i < _height; i++)
                for (var j = 0; j < _width; j++)
                {
                    var x = (int)((j - _width >> 1) * Math.Cos(angle) - (i - _height >> 1) * Math.Sin(angle)) + _width >> 1;
                    var y = (int)((j - _width >> 1) * Math.Sin(angle) + (i - _height >> 1) * Math.Cos(angle)) + _height >> 1;
                    if (x >= 0 && y >= 0 && x < _width && y < _height)
                        IntensityMatrix.Matrix[k][i] += InitMatrix.Matrix[x][y];
                }
            }
        }
        
        private void FftMatrixCalculation()
        {
            FftMatrix = new ComplexMatrix(_countSensor, _height, true);
            for (var k = 0; k < _countSensor; k++)
            {
                var fftResult = Fourier.FFT(IntensityMatrix.Matrix[k], true);
                for (var i = 0; i < _height >> 1; i++)
                {
                    FftMatrix.Matrix[k][i] = fftResult[i + _height >> 1];
                    FftMatrix.Matrix[k][i + _height >> 1] = fftResult[i];
                }
            }
        }

        private void RotatedFftMatrixCalculation()
        {
            RotatedFftMatrix = new ComplexMatrix(_width, _height, true);
            for (var k = 0; k < _width; k++)
            {
                var angle = -DeltaAngle * k;
                for (var i = 0; i < _height; i++)
                {
                    var x = (int)(-(i - _height >> 1) * Math.Sin(angle)) + _height >> 1;
                    var y = (int)((i - _height >> 1) * Math.Cos(angle)) + _height >> 1;
                    if (x >= 0 && y >= 0 && x < _width && y < _height)
                        RotatedFftMatrix.Matrix[y][x] += FftMatrix.Matrix[k][i];
                }
            }
        }

        /// <summary>
        /// Конвертация изображения в полутоновое.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Bitmap ConvertToHalftone(Bitmap bitmap)
        {
            var width = bitmap.Width;
            var height = bitmap.Height;

            var newBitmap = new Bitmap(width, height);

            for (var i = 0; i < bitmap.Width; i++)
            for (var j = 0; j < bitmap.Height; j++)
            {
                var pixel = bitmap.GetPixel(i, j);
                var halftoneValue = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
                newBitmap.SetPixel(i, j, Color.FromArgb(halftoneValue, halftoneValue, halftoneValue));
            }

            return newBitmap;
        }
    }
}