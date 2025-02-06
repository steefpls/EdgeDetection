using EdgeDetection.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetection.Core.Interfaces
{
    public interface IEdgeDetector
    {
        GrayscaleImage DetectEdges(GrayscaleImage image);
    }
}
