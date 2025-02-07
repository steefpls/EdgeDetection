using EdgeDetection.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetection.Core.Operators
{
    public class RobertsOperator : BaseOperator
    {
        public RobertsOperator()
        {
            InitializeKernels();
        }

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

        public override GrayscaleImage DetectEdges(GrayscaleImage image)
        {
            var gradientX = ApplyKernel(image, kernelX);
            var gradientY = ApplyKernel(image, kernelY);
            return CombineGradients(gradientX, gradientY);
        }
    }
}
