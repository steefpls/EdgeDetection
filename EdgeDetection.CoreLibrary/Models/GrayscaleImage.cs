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
            // Ensure the dimensions are valid
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Width and height must be greater than zero.");
            }
            Width = width;
            Height = height;
            pixels = new byte[height, width];
        }

        // Get the pixel value at the given coordinates
        public byte GetPixel(int x, int y) => pixels[y, x];

        // Set the pixel value at the given coordinates
        public void SetPixel(int x, int y, byte value)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                throw new ArgumentOutOfRangeException("Coordinates are out of bounds.");
            }
            pixels[y, x] = value;
        }
    }
}
