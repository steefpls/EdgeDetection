using EdgeDetection.Core.Enums;
using EdgeDetection.Core.Interfaces;
using EdgeDetection.Core.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetection.Core.Processing
{
    public class OperatorFactory
    {
        // Creates an instance of an edge detection operator based on the specified operator type.
        public IEdgeDetector CreateOperator(OperatorType operatorType)
        {
            switch (operatorType)
            {
                case OperatorType.Sobel:
                    return new SobelOperator();
                case OperatorType.Prewitt:
                    return new PrewittOperator();
                case OperatorType.Roberts:
                    return new RobertsOperator();
                default:
                    throw new ArgumentException("Invalid operator type specified."); // Should never happen
            }
        }
    }
}
