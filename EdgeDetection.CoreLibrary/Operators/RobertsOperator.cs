﻿using EdgeDetection.CoreLibrary.Models;

namespace EdgeDetection.CoreLibrary.Operators
{
    // This operator was added to ensure the code would be easily scalable and maintainable if need be
    public class RobertsOperator : BaseOperator
    {
        public RobertsOperator()
        {
            InitializeKernels();
        }

        // Initialize the transformation kernels with Roberts values
        private void InitializeKernels()
        {
            kernelX = new double[,]
            {
                { 1, 0 },
                { 0, -1 }
            };

            kernelY = new double[,]
            {
                { 0, 1 },
                { -1, 0 }
            };
        }

        // Kernel is applied differently from Prewitt and Sobel
        protected override double[,] ApplyKernel(GrayscaleImage image, double[,] kernel)
        {
            int width = image.Width;
            int height = image.Height;
            var result = new double[height, width];

            for (int y = 0; y < height - 1; y++)
            {
                for (int x = 0; x < width - 1; x++)
                {
                    double sum = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            sum += kernel[i, j] * image.GetPixel(x + j, y + i);
                        }
                    }
                    result[y, x] = sum;
                }
            }

            return result;
        }
    }
}
