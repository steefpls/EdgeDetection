using EdgeDetection.CoreLibrary.Processing;
using EdgeDetection.CoreLibrary.Enums;
using EdgeDetection.CoreLibrary.Operators;
using Xunit;
using System;

namespace EdgeDetection.Tests.Processing
{
    public class OperatorFactoryTests
    {
        private readonly OperatorFactory _factory;

        public OperatorFactoryTests()
        {
            _factory = new OperatorFactory();
        }

        [Theory]
        [InlineData(OperatorType.Sobel, typeof(SobelOperator))]
        [InlineData(OperatorType.Prewitt, typeof(PrewittOperator))]
        [InlineData(OperatorType.Roberts, typeof(RobertsOperator))]
        public void CreateOperator_ValidType_ReturnsCorrectOperator(OperatorType type, Type expectedType)
        {
            // Act
            var operatorFactory = _factory.CreateOperator(type);

            // Assert
            Assert.IsType(expectedType, operatorFactory);
        }

        [Fact]
        public void CreateOperator_InvalidType_ThrowsArgumentException()
        {
            // Arrange
            OperatorType invalidType = (OperatorType)999;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _factory.CreateOperator(invalidType));
        }
    }
}