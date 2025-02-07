using EdgeDetection.CoreLibrary.Processing;
using EdgeDetection.CoreLibrary.Enums;
using Xunit;
using System.Runtime.Versioning;

namespace EdgeDetection.Tests.Processing
{
    // Specifies that this test class only runs on Windows
    [SupportedOSPlatform("windows")]

    // Groups tests together under "ImageProcessingTests" to avoid conflicts
    [Collection("ImageProcessingTests")]
    [CollectionDefinition("ImageProcessingTests", DisableParallelization = true)] // Disables parallel execution for this collection

    public class ImageProcessorTests
    {
        private readonly ImageProcessor _processor; 
        private readonly string _testImagePath;

        
        public ImageProcessorTests()
        {
            var factory = new OperatorFactory(); 
            _processor = new ImageProcessor(factory); 

            // Generate a unique test image file path to avoid conflicts
            _testImagePath = Path.Combine(Path.GetTempPath(), $"test_image{Guid.NewGuid()}.png");

            // Ensure the file does not already exist
            Assert.False(File.Exists(_testImagePath), $"Expecting file {_testImagePath} to not exist!");

            // Create and save a simple 10x10 bitmap image for testing
            using (var bitmap = new System.Drawing.Bitmap(10, 10))
            {
                bitmap.Save(_testImagePath);
            }
        }

        [Fact]
        // This test is expected to pass since the image is valid
        public void ProcessImage_ValidImage_ReturnsProcessedImage()
        {
            var result = _processor.ProcessImage(_testImagePath);

            // Assert: Ensure processing returns a valid image of the expected dimensions
            Assert.NotNull(result);
            Assert.Equal(10, result.Width);
            Assert.Equal(10, result.Height);
        }

        [Fact]
        // This test is expected to throw a FileNotFoundException since the file does not exist
        public void ProcessImage_InvalidPath_ThrowsFileNotFoundException()
        {
            var fakeImagePath = "nonexistent.jpg";

            // Ensure the fake file does not exist
            Assert.False(File.Exists(fakeImagePath), $"File {fakeImagePath} should not exist!");

            // Assert: Processing an invalid path should throw FileNotFoundException
            Assert.Throws<FileNotFoundException>(() => _processor.ProcessImage(fakeImagePath));
        }

        [Fact]
        // This test is for clearing the collection after all tests have run
        public void Dispose()
        {
            // Cleanup: Delete the test image file if it exists
            if (File.Exists(_testImagePath))
            {
                File.Delete(_testImagePath);
            }
        }
    }
}
