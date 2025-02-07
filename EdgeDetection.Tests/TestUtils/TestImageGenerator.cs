using EdgeDetection.CoreLibrary.Models;

namespace EdgeDetection.Tests.TestUtils
{
    public static class TestImageGenerator
    {
        public static GrayscaleImage CreateTestImage(int width, int height)
        {
            var image = new GrayscaleImage(width, height);

            // Create a simple gradient pattern
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte value = (byte)(((x + y) % 256));
                    image.SetPixel(x, y, value);
                }
            }

            return image;
        }

        public static GrayscaleImage CreateUniformImage(int width, int height, byte value)
        {
            var image = new GrayscaleImage(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    image.SetPixel(x, y, value);
                }
            }

            return image;
        }
    }
}