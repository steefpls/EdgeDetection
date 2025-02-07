using EdgeDetection.Core.Models;
using Xunit;

namespace EdgeDetection.Tests.Models
{
    public class GrayscaleImageTests
    {
        [Fact]
        public void Constructor_ValidDimensions_CreatesImage()
        {
            // Arrange & Act
            var image = new GrayscaleImage(10, 10);

            // Assert
            Assert.Equal(10, image.Width);
            Assert.Equal(10, image.Height);
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(10, 0)]
        [InlineData(-1, 10)]
        [InlineData(10, -1)]
        public void Constructor_InvalidDimensions_ThrowsArgumentException(int width, int height)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new GrayscaleImage(width, height));
        }

        [Fact]
        public void SetAndGetPixel_ValidCoordinates_StoresAndRetrievesValue()
        {
            // Arrange
            var image = new GrayscaleImage(10, 10);

            // Act
            image.SetPixel(5, 5, 128);
            var value = image.GetPixel(5, 5);

            // Assert
            Assert.Equal(128, value);
        }

        [Theory]
        [InlineData(-1, 5)]
        [InlineData(5, -1)]
        [InlineData(10, 5)]
        [InlineData(5, 10)]
        public void SetPixel_InvalidCoordinates_ThrowsArgumentOutOfRangeException(int x, int y)
        {
            // Arrange
            var image = new GrayscaleImage(10, 10);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => image.SetPixel(x, y, 128));
        }
    }
}