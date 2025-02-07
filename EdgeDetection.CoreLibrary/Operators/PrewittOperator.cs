using EdgeDetection.CoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetection.CoreLibrary.Operators
{
    public class PrewittOperator : BaseOperator
    {
        // Constructor
        public PrewittOperator()
        {
            InitializeKernels();
        }

        // Initialize the transformation kernels with Prewitt values
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
    }
}
