﻿using EdgeDetection.Core.Enums;
using EdgeDetection.Core.Interfaces;
using EdgeDetection.Core.Models;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EdgeDetection.Core.Processing
{
    public class ImageProcessor : IImageProcessor
    {
        private readonly OperatorFactory operatorFactory;
        private IEdgeDetector currentOperator;

        public ImageProcessor(OperatorFactory operatorFactory)
        {
            this.operatorFactory = operatorFactory;
            this.currentOperator = operatorFactory.CreateOperator(OperatorType.Sobel); // Default
        }
        
        public void SetOperator(OperatorType type)
        {
            currentOperator = operatorFactory.CreateOperator(type);
        }

        public GrayscaleImage ProcessImage(string imagePath)
        {
            var realPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);
            
            
            var bitmap = new Bitmap(realPath);
            var grayscale = ConvertToGrayscale(bitmap);
            
            return currentOperator.DetectEdges(grayscale);
        }

        public void SaveImage(GrayscaleImage image, string path)
        {
            var bitmap = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var pixel = image.GetPixel(x, y);
                    bitmap.SetPixel(x, y, Color.FromArgb(pixel, pixel, pixel));
                }
            }
            bitmap.Save(path);
        }

        private GrayscaleImage ConvertToGrayscale(System.Drawing.Bitmap bitmap)
        {
            var result = new GrayscaleImage(bitmap.Width, bitmap.Height);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    var gray = (byte)((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));
                    result.SetPixel(x, y, gray);
                }
            }

            return result;
        }
    }
}
