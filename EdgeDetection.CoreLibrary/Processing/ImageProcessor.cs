using EdgeDetection.CoreLibrary.Enums;
using EdgeDetection.CoreLibrary.Interfaces;
using EdgeDetection.CoreLibrary.Models;
using System.Drawing;
using System.Runtime.Versioning;

namespace EdgeDetection.CoreLibrary.Processing
{
    [SupportedOSPlatform("windows")]
    public class ImageProcessor : IImageProcessor
    {
        private readonly OperatorFactory operatorFactory;
        private IEdgeDetector currentOperator;

        // Constructor
        public ImageProcessor(OperatorFactory operatorFactory)
        {
            this.operatorFactory = operatorFactory;
            this.currentOperator = operatorFactory.CreateOperator(OperatorType.Sobel); // Default
        }
        
        // Creates an operator and sets it as the currentOperator
        public void SetOperator(OperatorType type)
        {
            currentOperator = operatorFactory.CreateOperator(type);
        }

        // Converts Image to grayscale then processes it using the current operator
        public GrayscaleImage ProcessImage(string path)
        {
            Console.WriteLine($"Processing image: {path}");
            // Check if file exists before creating bitmap
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.", path);
            }

            try
            {
                var bitmap = new Bitmap(path);
                var grayscale = ConvertToGrayscale(bitmap);
                return currentOperator.DetectEdges(grayscale);
            }
            catch (Exception)
            {
                Console.WriteLine($"Bitmap Creation Failed.");
                throw;
            }
        }

        // Saves bitmap to image file
        public void SaveImage(GrayscaleImage image, string path)
        {
            var bitmap = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var pixel = image.GetPixel(x, y);
                    bitmap.SetPixel(x, y, Color.FromArgb(pixel, pixel, pixel));
                }
            }
            bitmap.Save(path);
        }

        // Converts bitmap to grayscale image
        private GrayscaleImage ConvertToGrayscale(Bitmap bitmap)
        {
            var result = new GrayscaleImage(bitmap.Width, bitmap.Height);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    var gray = (byte)((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));
                    result.SetPixel(x, y, gray);
                }
            }

            return result;
        }
    }
}
