namespace EdgeDetection.CoreLibrary.Models
{
    public class GrayscaleImage
    {
        private readonly byte[,] pixels;

        public int Width { get; }
        public int Height { get; }

        // Initialize the image with the given width and height
        public GrayscaleImage(int width, int height)
        {
            Width = width;
            Height = height;
            pixels = new byte[height, width];
        }

        // Get the pixel value at the given coordinates
        public byte GetPixel(int x, int y) => pixels[y, x];

        // Set the pixel value at the given coordinates
        public void SetPixel(int x, int y, byte value) => pixels[y, x] = value;
    }
}
