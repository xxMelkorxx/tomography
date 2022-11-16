﻿using System;
using System.Drawing;
using System.Collections.Generic;

namespace tomography
{
    public class Tomography
    {
        public ComplexMatrix InitMatrix;
        public List<ComplexMatrix> RotatedMatrixList;
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
            RotatedMatrixList = new List<ComplexMatrix>();

            var halfWidth = _width >> 1;
            var halfHeight = _height >> 1;

            for (var k = 0; k < _countSensor; k++)
            {
                var angle = DeltaAngle * k;
                var cos = Math.Cos(angle);
                var sin = Math.Sin(angle);
                RotatedMatrixList.Add(new ComplexMatrix(_width, _height));
                for (var i = 0; i < _height; i++)
                for (var j = 0; j < _width; j++)
                {
                    var x = (int)((j - halfWidth) * cos - (i - halfHeight) * sin) + halfWidth;
                    var y = (int)((j - halfWidth) * sin + (i - halfHeight) * cos) + halfHeight;
                    if (x >= 0 && y >= 0 && x < _width && y < _height)
                        IntensityMatrix.Matrix[k][i] += RotatedMatrixList[k].Matrix[j][i] = InitMatrix.Matrix[x][y];
                }
            }
        }

        private void FftMatrixCalculation()
        {
            FftMatrix = new ComplexMatrix(_countSensor, _height, true);

            var halfHeight = _height >> 1;

            for (var k = 0; k < _countSensor; k++)
            {
                var fftResult = Fourier.FFT(IntensityMatrix.Matrix[k], true);
                for (var i = 0; i < halfHeight; i++)
                {
                    FftMatrix.Matrix[k][i] = fftResult[i + halfHeight];
                    FftMatrix.Matrix[k][i + halfHeight] = fftResult[i];
                }
            }
        }

        private void RotatedFftMatrixCalculation()
        {
            RotatedFftMatrix = new ComplexMatrix(_width, _height, true);

            var halfWidth = _width >> 1;
            var halfHeight = _height >> 1;

            for (var k = 0; k < _width; k++)
            {
                var angle = -DeltaAngle * k;
                for (var i = 0; i < _height; i++)
                {
                    var x = (int)(-(i - halfWidth) * Math.Sin(angle)) + halfWidth;
                    var y = (int)((i - halfHeight) * Math.Cos(angle)) + halfHeight;
                    if (x >= 0 && y >= 0 && x < _width && y < _height)
                        RotatedFftMatrix.Matrix[y][x] += FftMatrix.Matrix[k][i] / _countSensor;
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