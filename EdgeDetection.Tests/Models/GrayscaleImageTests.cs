using EdgeDetection.CoreLibrary.Models;
using Xunit;

namespace EdgeDetection.Tests.Models
{
    public class GrayscaleImageTests
    {
        [Fact]
        // This test is meant to test the constructor and should create an image with the given dimensions
        public void Constructor_ValidDimensions_CreatesImage()
        {
            var image = new GrayscaleImage(10, 10);

            Assert.Equal(10, image.Width);
            Assert.Equal(10, image.Height);
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(10, 0)]
        [InlineData(-1, 10)]
        [InlineData(10, -1)]
        // This test is meant to test the constructor and should throw an exception for invalid dimensions
        public void Constructor_InvalidDimensions_ThrowsArgumentException(int width, int height)
        {
            Assert.Throws<ArgumentException>(() => new GrayscaleImage(width, height));
        }

        // This test is meant to test the GetPixel method and should return the value of the pixel at the given coordinates
        [Fact]
        public void SetAndGetPixel_ValidCoordinates_StoresAndRetrievesValue()
        {
            var image = new GrayscaleImage(10, 10);

            image.SetPixel(5, 5, 128);
            var value = image.GetPixel(5, 5);

            Assert.Equal(128, value);
        }

        [Theory]
        [InlineData(-1, 5)]
        [InlineData(5, -1)]
        [InlineData(10, 5)]
        [InlineData(5, 10)]

        // This test is meant to test the SetPixel method, and should throw an exception for invalid coordinates
        public void SetPixel_InvalidCoordinates_ThrowsArgumentOutOfRangeException(int x, int y)
        {
            var image = new GrayscaleImage(10, 10);
            Assert.Throws<ArgumentOutOfRangeException>(() => image.SetPixel(x, y, 128));
        }
    }
}