using EdgeDetection.Core.Models;
using EdgeDetection.Core.Enums;

namespace EdgeDetection.Core.Interfaces
{
    public interface IImageProcessor
    {
        GrayscaleImage ProcessImage(string imagePath);
        void SetOperator(OperatorType operatorType);
        void SaveImage(GrayscaleImage image, string path);
    }
}
