using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetection.Core.Models
{
    public class GrayscaleImage
    {
        private readonly byte[,] pixels;

        public int Width { get; }
        public int Height { get; }

        public GrayscaleImage(int width, int height)
        {
            Width = width;
            Height = height;
            pixels = new byte[height, width];
        }

        public byte GetPixel(int x, int y) => pixels[y, x];
        public void SetPixel(int x, int y, byte value) => pixels[y, x] = value;
    }
}
