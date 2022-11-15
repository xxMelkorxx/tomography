using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace tomography
{
    public class Tomography
    {
        public int Width => InitMatrix.Width;
        public int Height => InitMatrix.Height;

        public ComplexMatrix InitMatrix;
        public ComplexMatrix IntensityMatrix;
        public ComplexMatrix SpectrumMatrix;

        private double DeltaAngle => 2 * Math.PI / _countIntesity;
        private int _countIntesity;

        private int _oldWidth;
        private int _oldHeight;

        public Tomography(Bitmap bitmap, int width, int height, int countIntesity, int countSensor)
        {
            _oldWidth = bitmap.Width;
            _oldHeight = bitmap.Height;
            _countIntesity = countIntesity;

            var newBitmap = ConvertToHalftone(Interpolation.BilinearInterpolation(bitmap, width, height));
            InitMatrix = new ComplexMatrix(newBitmap);
        }

        public void IntensityMatrixCalculation()
        {
            IntensityMatrix = new ComplexMatrix(_countIntesity, Height);

            for (var k = 0; k < _countIntesity; k++)
            {
                var angle =  DeltaAngle * k;
                for (var i = 0; i < Height; i++)
                for (var j = 0; j < Width; j++)
                {
                    var x = (int)(j * Math.Cos(angle) - i * Math.Sin(angle));
                    var y = (int)(j * Math.Sin(angle) + i * Math.Cos(angle));
                    if (x >= 0 && y >= 0 && x < Width && y < Height)
                        IntensityMatrix.Matrix[k][i] += InitMatrix.Matrix[x][y];
                }
            }
        }

        public static Bitmap RotateImage(Bitmap bitmap, double angle)
        {
            var width = bitmap.Width;
            var height = bitmap.Height;

            var result = new Bitmap(width, height);
            angle = Math.PI * angle / 180;
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    var x = (int)(i * Math.Cos(angle) - j * Math.Sin(angle));
                    var y = (int)(i * Math.Sin(angle) + j * Math.Cos(angle));
                    if (x >= 0 && y >= 0 && x < width && y < height)
                        result.SetPixel(i, j, bitmap.GetPixel(x, y));
                }
            }

            return result;
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