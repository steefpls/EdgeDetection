using EdgeDetection.CoreLibrary.Models;

namespace EdgeDetection.CoreLibrary.Interfaces
{
    public interface IEdgeDetector
    {
        GrayscaleImage DetectEdges(GrayscaleImage image);
    }
}
