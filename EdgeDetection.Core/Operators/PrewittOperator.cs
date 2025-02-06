using EdgeDetection.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetection.Core.Operators
{
    public class PrewittOperator : BaseOperator
    {
        public PrewittOperator()
        {
            InitializeKernels();
        }

        private void InitializeKernels()
        {
            kernelX = new double[,]
            {
                { -1, 0, 1 },
                { -1, 0, 1 },
                { -1, 0, 1 }
            };

            kernelY = new double[,]
            {
                { -1, -1, -1 },
                {  0,  0,  0 },
                {  1,  1,  1 }
            };
        }

        public override GrayscaleImage DetectEdges(GrayscaleImage image)
        {
            var gradientX = ApplyKernel(image, kernelX);
            var gradientY = ApplyKernel(image, kernelY);
            return CombineGradients(gradientX, gradientY);
        }
    }
}
