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
        // This test is expected to pass since the operator type is valid
        public void CreateOperator_ValidType_ReturnsCorrectOperator(OperatorType type, Type expectedType)
        {
            var operatorFactory = _factory.CreateOperator(type);
            Assert.IsType(expectedType, operatorFactory);
        }

        [Fact]
        // This test is expected to throw an ArgumentException since the operator type is invalid
        public void CreateOperator_InvalidType_ThrowsArgumentException()
        {
            OperatorType invalidType = (OperatorType)999;

            Assert.Throws<ArgumentException>(() => _factory.CreateOperator(invalidType));
        }
    }
}