using EdgeDetection.Core.Models;

namespace EdgeDetection.Core.Interfaces
{
    public interface IEdgeDetector
    {
        GrayscaleImage DetectEdges(GrayscaleImage image);
    }
}
