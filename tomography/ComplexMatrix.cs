using System;
using System.Numerics;
using System.Drawing;
using System.Linq;

namespace tomography
{
    public struct ComplexMatrix
    {
        public int Width => Matrix.Length;
        public int Height => Matrix[0].Length;

        public Complex[][] Matrix;
        public bool IsSpectrum;

        /// <summary>
        /// Конструктор. Инициализирует MatrixImage с указанным размером.
        /// </summary>
        /// <param name="width">Ширина</param>
        /// <param name="height">Спектр</param>
        public ComplexMatrix(int width, int height, bool isSpectrum = false)
        {
            IsSpectrum = isSpectrum;
            Matrix = new Complex[width][];
            for (var i = 0; i < width; i++)
                Matrix[i] = new Complex[height];
        }

        /// <summary>
        /// Конструктор. Создаёт из bitmap.
        /// </summary>
        /// <param name="bitmap"></param>
        public ComplexMatrix(Bitmap bitmap, bool isSpectrum = false)
        {
            IsSpectrum = isSpectrum;
            Matrix = new Complex[bitmap.Width][];
            for (var i = 0; i < Width; i++)
            {
                Matrix[i] = new Complex[bitmap.Height];
                for (var j = 0; j < Height; j++)
                    Matrix[i][j] = bitmap.GetPixel(i, j).R;
            }
        }

        /// <summary>
        /// Матрица в виде формате Bitmap. 
        /// </summary>
        public Bitmap Bitmap
        {
            get
            {
                var bmp = new Bitmap(Width, Height);
                var matRgb = MatrixRgb;

                for (var i = 0; i < Width; i++)
                    for (var j = 0; j < Height; j++)
                        bmp.SetPixel(i, j, Color.FromArgb(matRgb[i][j], matRgb[i][j], matRgb[i][j]));

                return bmp;
            }
        }

        /// <summary>
        /// Отнормализованная матрица со значенияими в пределах от 0 до 255.  
        /// </summary>
        public byte[][] MatrixRgb
        {
            get
            {
                double max = 0;
                for (var i = 0; i < Width; i++)
                    if (Matrix[i].Max(j => j.Magnitude) > max)
                        max = Matrix[i].Max(j => j.Magnitude);

                var normMatrix = new double[Width][];
                var matrixRgb = new byte[Width][];
                for (var i = 0; i < Width; i++)
                {
                    normMatrix[i] = new double[Height];
                    matrixRgb[i] = new byte[Height];
                    for (var j = 0; j < Height; j++)
                        normMatrix[i][j] = Matrix[i][j].Magnitude / max * 255;
                }

                if (!IsSpectrum)
                    for (var i = 0; i < Width; i++)
                        for (var j = 0; j < Height; j++)
                            matrixRgb[i][j] = (byte)normMatrix[i][j];
                else
                {
                    double logMax = 0;
                    for (var i = 0; i < Width; i++)
                        for (var j = 0; j < Height; j++)
                        {
                            var value = Math.Sqrt(Math.Log(1 + normMatrix[i][j]));
                            if (value > logMax)
                                logMax = value;
                        }

                    for (var i = 0; i < Width; i++)
                        for (var j = 0; j < Height; j++)
                            matrixRgb[i][j] = (byte)(Math.Sqrt(Math.Log(1 + normMatrix[i][j])) / logMax * 255);
                }

                return matrixRgb;
            }
        }
    }
}