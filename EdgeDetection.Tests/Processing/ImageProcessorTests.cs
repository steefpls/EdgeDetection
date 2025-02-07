using EdgeDetection.Core.Processing;
using EdgeDetection.Core.Enums;
using Xunit;

namespace EdgeDetection.Tests.Processing
{
    public class ImageProcessorTests
    {
        private readonly ImageProcessor _processor;
        private readonly string _testImagePath;

        public ImageProcessorTests()
        {
            var factory = new OperatorFactory();
            _processor = new ImageProcessor(factory);

            // Create and save a test image
            _testImagePath = Path.Combine(Path.GetTempPath(), "test_image.png");
            using (var bitmap = new System.Drawing.Bitmap(10, 10))
            {
                bitmap.Save(_testImagePath);
            }
        }

        [Fact]
        public void ProcessImage_ValidImage_ReturnsProcessedImage()
        {
            // Act
            var result = _processor.ProcessImage(_testImagePath);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.Width);
            Assert.Equal(10, result.Height);
        }

        [Fact]
        public void ProcessImage_InvalidPath_ThrowsFileNotFoundException()
        {
            // Act & Assert
            Assert.Throws<FileNotFoundException>(() =>
                _processor.ProcessImage("nonexistent.jpg"));
        }

        [Theory]
        [InlineData(OperatorType.Sobel)]
        [InlineData(OperatorType.Prewitt)]
        [InlineData(OperatorType.Roberts)]
        public void SetOperator_ValidType_SwitchesOperatorSuccessfully(OperatorType type)
        {
            // Act
            _processor.SetOperator(type);
            var result = _processor.ProcessImage(_testImagePath);

            // Assert
            Assert.NotNull(result);
        }

        public void Dispose()
        {
            // Cleanup test file
            if (File.Exists(_testImagePath))
            {
                File.Delete(_testImagePath);
            }
        }
    }
}