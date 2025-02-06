using EdgeDetection.Core.Interfaces;
using EdgeDetection.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetection.Core.Operators
{
    public abstract class BaseOperator:IEdgeDetector
    {
        protected double[,] kernelX;
        protected double[,] kernelY;

        public abstract GrayscaleImage DetectEdges(GrayscaleImage image);

        protected double[,] ApplyKernel(GrayscaleImage image, double[,] kernel)
        {
            // Kernel application implementation
            double[,] sum = new double[image.Height, image.Width];
            return sum;
        }

        protected GrayscaleImage CombineGradients(double[,] gradientX, double[,] gradientY)
        {
            // Gradient combination implementation
            return new GrayscaleImage(gradientX.GetLength(1), gradientX.GetLength(0));
        }
    }
}
