using EdgeDetection.Core.Models;
using EdgeDetection.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetection.Core.Interfaces
{
    public interface IImageProcessor
    {
        void SetOperator(OperatorType operatorType);
        GrayscaleImage ProcessImage(string imagePath);
        void SaveImage(GrayscaleImage image, string path);
    }
}
