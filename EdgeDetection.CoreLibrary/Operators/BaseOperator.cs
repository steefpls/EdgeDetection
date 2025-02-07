using EdgeDetection.CoreLibrary.Interfaces;
using EdgeDetection.CoreLibrary.Models;
using System;

namespace EdgeDetection.CoreLibrary.Operators
{
    public abstract class BaseOperator : IEdgeDetector
    {
        // Transformation kernels
        protected double[,] kernelX = new double[3, 3]; // 3x3 matrix default
        protected double[,] kernelY = new double[3, 3];

        // Detect edges in an image using the operator's kernels
        protected virtual double[,] ApplyKernel(GrayscaleImage image, double[,] kernel)
        {
            int width = image.Width;
            int height = image.Height;
            var result = new double[height, width];

            // This implementation skips border pixels, and is intentional
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    double sum = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            sum += kernel[i + 1, j + 1] * image.GetPixel(x + j, y + i);
                        }
                    }
                    result[y, x] = sum;
                }
            }

            return result;
        }

        // Combines the results of the X and Y kernels to get the final edge detection result
        protected GrayscaleImage CombineGradients(double[,] gradientX, double[,] gradientY)
        {
            int height = gradientX.GetLength(0);
            int width = gradientX.GetLength(1);
            var result = new GrayscaleImage(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double magnitude = Math.Sqrt(gradientX[y, x] * gradientX[y, x] + gradientY[y, x] * gradientY[y, x]);

                    // Normalize to 0-255 range
                    byte pixel = (byte)Math.Min(255, Math.Max(0, magnitude));
                    result.SetPixel(x, y, pixel);
                }
            }

            return result;
        }

        // Returns Grayscale Image with edges represented as white pixels
        public virtual GrayscaleImage DetectEdges(GrayscaleImage image)
        {
            var gradientX = ApplyKernel(image, kernelX);
            var gradientY = ApplyKernel(image, kernelY);
            return CombineGradients(gradientX, gradientY);
        }
    }
}
