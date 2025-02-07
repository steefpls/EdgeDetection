using EdgeDetection.CoreLibrary.Models;
using EdgeDetection.CoreLibrary.Enums;

namespace EdgeDetection.CoreLibrary.Interfaces
{
    public interface IImageProcessor
    {
        GrayscaleImage ProcessImage(string imagePath);
        void SetOperator(OperatorType operatorType);
        void SaveImage(GrayscaleImage image, string path);
    }
}
