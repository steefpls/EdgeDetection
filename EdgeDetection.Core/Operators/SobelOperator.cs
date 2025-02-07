using EdgeDetection.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetection.Core.Operators
{
    public class SobelOperator : BaseOperator
    {
        public SobelOperator()
        {
            InitializeKernels();
        }
        // Initialize the transformation kernels with Sobel values
        private void InitializeKernels()
        {
            kernelX = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            kernelY = new double[,]
            {
                { -1, -2, -1 },
                {  0,  0,  0 },
                {  1,  2,  1 }
            };
        }
    }
}
