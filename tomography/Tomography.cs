using System;
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

		private int _size;
		private int _halfSize;
		private int _countSensor;
		private double DeltaAngle => Math.PI / _countSensor;
		//private double DeltaAngle => Math.PI / 2 / _countSensor;

		public Tomography(int size, int countSensor)
		{
			_size = size;
			_halfSize = size >> 1;
			_countSensor = countSensor;

			InitMatrix = new ComplexMatrix(_size, _size);
			InitImage = new Bitmap(_size, _size);
			CreateGaussImage(new[] { 1d, 1d, 1d }, new[] { 10d, 10d, 10d }, new[] { 10d, 10d, 10d }, new[] { 50d, 100d, 150d }, new[] { 50d, 100d, 150d });
			IntensityMatrixCalculation();
			FftMatrixCalculation();
			RotatedFftMatrixCalculation();
			RestoredMatrix = Fourier.FFT_2D(RotatedFftMatrix, false);
		}

		public Tomography(Bitmap bitmap, int size, int countSensor)
		{
			_size = size;
			_halfSize = size >> 1;
			_countSensor = countSensor;

			var oldWidth = bitmap.Width;
			var oldHeight = bitmap.Height;

			InitImage = ConvertToHalftone(bitmap);
			var s = (int)(_size * Math.Sqrt(0.5));
			var temp = new ComplexMatrix(Interpolation.BilinearInterpolation(InitImage, s, s));
			InitMatrix = new ComplexMatrix(_size, _size);
			for (var i = 0; i < s; i++)
				for (var j = 0; j < s; j++)
					InitMatrix.Matrix[i + (_size - s) / 2][j + (_size - s) / 2] = temp.Matrix[i][j];
			IntensityMatrixCalculation();
			FftMatrixCalculation();
			RotatedFftMatrixCalculation();
			RestoredMatrix = Fourier.FFT_2D(RotatedFftMatrix, false);
			RestoredImage = Interpolation.BilinearInterpolation(RestoredMatrix.GetBitmap(), oldWidth, oldHeight);
		}

		private void IntensityMatrixCalculation()
		{
			IntensityMatrix = new ComplexMatrix(_countSensor, _size);
			RotatedMatrixList = new List<ComplexMatrix>();

			for (var k = 0; k < _countSensor; k++)
			{
				var angle = DeltaAngle * k;
				var cos = Math.Cos(angle);
				var sin = Math.Sin(angle);
				RotatedMatrixList.Add(new ComplexMatrix(_size, _size));
				for (var i = 0; i < _size; i++)
					for (var j = 0; j < _size; j++)
					{
						var x = (int)((j - _halfSize) * cos - (i - _halfSize) * sin) + _halfSize;
						var y = (int)((j - _halfSize) * sin + (i - _halfSize) * cos) + _halfSize;
						if (x >= 0 && y >= 0 && x < _size && y < _size)
							IntensityMatrix.Matrix[k][i] += RotatedMatrixList[k].Matrix[j][i] = InitMatrix.Matrix[x][y];
					}
			}
		}

		private void FftMatrixCalculation()
		{
			FftMatrix = new ComplexMatrix(_countSensor, _size, true);
			for (var k = 0; k < _countSensor; k++)
			{
				var fftResult = Fourier.FFT(IntensityMatrix.Matrix[k], true);
				for (var i = 0; i < _halfSize; i++)
				{
					FftMatrix.Matrix[k][i] = fftResult[i + _halfSize];
					FftMatrix.Matrix[k][i + _halfSize] = fftResult[i];
				}
				//for (var i = 0; i < _size; i++)
				//    FftMatrix.Matrix[k][i] = fftResult[i];
			}
		}

		private void RotatedFftMatrixCalculation()
		{
			RotatedFftMatrix = new ComplexMatrix(_size, _size, true);

			for (var k = 0; k < _countSensor; k++)
			{
				var angle = -DeltaAngle * k;
				var sin = Math.Sin(angle + Math.PI / 2);
				var cos = Math.Cos(angle + Math.PI / 2);
				for (var i = 0; i < _size; i++)
				{
					var x = (int)(-(i - _halfSize) * sin) + _halfSize;
					var y = (int)((i - _halfSize) * cos) + _halfSize;
					if (x >= 0 && y >= 0 && x < _size && y < _size)
						RotatedFftMatrix.Matrix[y][x] += FftMatrix.Matrix[k][i];
				}
				//for (var i = 0; i < _halfSize; i++)
				//{
				//    var x = (int)(-i * sin);
				//    var y = (int)(i * cos);
				//    if (x >= 0 && y >= 0 && x < _size && y < _size)
				//    {
				//        RotatedFftMatrix.Matrix[y][x] += FftMatrix.Matrix[k][i];
				//        RotatedFftMatrix.Matrix[_size - y - 1][_size - x - 1] += FftMatrix.Matrix[k][_size - i - 1];
				//    }
				//}
			}

			//var rCutoff = 25d;
			//for (var i = 0; i < _size; i++)
			//    for (var j = 0; j < _size; j++)
			//    {
			//        if (Math.Pow(_halfSize - i, 2) + Math.Pow(_halfSize - j, 2) >= rCutoff * rCutoff)
			//            RotatedFftMatrix.Matrix[i][j] = 0;
			//    }
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

		/// <summary>
		/// Функция двумерного Гауссова купола.
		/// </summary>
		/// <param name="x">Координата Х</param>
		/// <param name="y">Координата Y</param>
		/// <param name="a">Амплитуда</param>
		/// <param name="sigmaX">Ширина купола по Х</param>
		/// <param name="sigmaY">Ширина купола по Y</param>
		/// <param name="shiftX">Сдвиг по X</param>
		/// <param name="shiftY">Сдвиг по Y.</param>
		/// <returns>Возвращает значение в точке (x,y).</returns>
		private static double GaussFunction(double x, double y, double a, double sigmaX, double sigmaY, double shiftX, double shiftY)
		{
			return a * Math.Exp(-(Math.Pow((x - shiftX) / sigmaX, 2) + Math.Pow((y - shiftY) / sigmaY, 2)));
		}

		/// <summary>
		/// Создание изображения из Гауссовых куполов.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="sigmaX"></param>
		/// <param name="sigmaY"></param>
		/// <param name="shiftX"></param>
		/// <param name="shiftY"></param>
		public void CreateGaussImage(double[] a, double[] sigmaX, double[] sigmaY, double[] shiftX, double[] shiftY)
		{
			for (var i = 0; i < InitMatrix.Width; i++)
				for (var j = 0; j < InitImage.Height; j++)
					for (var k = 0; k < a.Length; k++)
						InitMatrix.Matrix[i][j] += GaussFunction(i, j, a[k], sigmaX[k], sigmaY[k], shiftX[k], shiftY[k]);

			InitImage = InitMatrix.GetBitmap();
		}
	}
}