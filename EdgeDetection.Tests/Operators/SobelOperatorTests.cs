using EdgeDetection.CoreLibrary.Operators;
using EdgeDetection.Tests.TestUtils;
using Xunit;

namespace EdgeDetection.Tests.Operators
{
    public class SobelOperatorTests
    {
        private readonly SobelOperator _operator;

        public SobelOperatorTests()
        {
            _operator = new SobelOperator();
        }

        // This test is expected to pass since the operator should detect no edges in a uniform image
        [Fact]
        public void DetectEdges_UniformImage_ReturnsUniformImage()
        {
            // Generate a uniform image
            var image = TestImageGenerator.CreateUniformImage(10, 10, 128);

            // Act
            var result = _operator.DetectEdges(image);

            // Assert
            for (int y = 1; y < result.Height - 1; y++)
            {
                for (int x = 1; x < result.Width - 1; x++)
                {
                    Assert.Equal(0, result.GetPixel(x, y));
                }
            }
        }

        // This test is expected to pass since the operator should detect edges in a non-uniform image
        [Fact]
        public void DetectEdges_GradientImage_DetectsEdges()
        {
            // Generate a gradient image
            var image = TestImageGenerator.CreateTestImage(10, 10);

            // Act
            var result = _operator.DetectEdges(image);

            // Assert
            bool hasNonZeroPixels = false;
            for (int y = 1; y < result.Height - 1; y++)
            {
                for (int x = 1; x < result.Width - 1; x++)
                {
                    if (result.GetPixel(x, y) > 0)
                    {
                        hasNonZeroPixels = true;
                        break;
                    }
                }
            }
            Assert.True(hasNonZeroPixels);
        }
    }
}
