using CalculatorWebApp.ExtensionMethods;
using CalculatorWebApp.Models;
using Xunit;

namespace CalculatorWebApp.Tests.ExtensionMethods
{
    public class CalculationsTests
    {
        [Theory]
        [InlineData(0.1, 0.2, 0.02)]
        [InlineData(1, 0.2, 0.2)]
        [InlineData(0.5, 0.5, 0.25)]
        [InlineData(0.888, 0.2, 0.1776)]
        [InlineData(0, 0.29, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0.9999999999, 0.2, 0.19999999998)]
        public void CalculateResults__OperationTypeCombinedWith_ReturnsAsExpected(decimal numberA, decimal numberB, decimal result)
        {
            // Arrange
            var calculation = new Calculation()
            {
                NumberA = numberA,
                NumberB = numberB,
                Operation = Calculation.OperationType.CombinedWith
            };

            // Act
            var calculationResult = Calculations.CalculateResult(calculation);

            // Assert 
            Assert.Equal(result, calculationResult);
        }

        [Theory]
        [InlineData(0.1, 0.2, 0.28)]
        [InlineData(1, 0.2, 1)]
        [InlineData(0.5, 0.5, 0.75)]
        [InlineData(0.888, 0.2, 0.9104)]
        [InlineData(0, 0.29, 0.29)]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0.9999999999, 0.2, 0.99999999992)]
        public void CalculateResults__OperationTypeEither_ReturnsAsExpected(decimal numberA, decimal numberB, decimal result)
        {
            // Arrange
            var calculation = new Calculation()
            {
                NumberA = numberA,
                NumberB = numberB,
                Operation = Calculation.OperationType.Either
            };

            // Act
            var calculationResult = Calculations.CalculateResult(calculation);

            // Assert 
            Assert.Equal(result, calculationResult);
        }

        [Theory]
        [InlineData(-0.1, 0.2, -0.02)]
        [InlineData(1, 0.2, 0.2)]
        [InlineData(0.5, 0.5, 0.25)]
        [InlineData(0.888, 0.2, 0.1776)]
        [InlineData(0, 0.29, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0.9999999999, 0.2, 0.19999999998)]
        public void CalculateResults__Multiply_ReturnsAsExpected(decimal numberA, decimal numberB, decimal result)
        {
            // Arrange


            // Act
            var calculationResult = Calculations.Multiply(numberA, numberB);

            // Assert 
            Assert.Equal(result, calculationResult);
        }

        [Theory]
        [InlineData(0.1, 0.2, 0.3)]
        [InlineData(1, 0.2, 1.2)]
        [InlineData(0.5, -0.5, 0)]
        [InlineData(0.888, 0.2, 1.088)]
        [InlineData(0, 0.29, 0.29)]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(0.9999999999, 0.2, 1.1999999999)]
        public void CalculateResults__Add_ReturnsAsExpected(decimal numberA, decimal numberB, decimal result)
        {
            // Arrange


            // Act
            var calculationResult = Calculations.Add(numberA, numberB);

            // Assert 
            Assert.Equal(result, calculationResult);
        }
    }
}
