using CalculatorWebApp.ExtensionMethods;
using CalculatorWebApp.Models;
using Xunit;

namespace CalculatorWebApp.Tests.ExtensionMethods
{
    public class LoggingTests
    {
        [Fact]
        public void BuildCurrentLog()
        {
            // Arrange
            var calculation = new Calculation()
            {
                NumberA = 1,
                NumberB = 0.2M,
                Operation = Calculation.OperationType.CombinedWith,
                Result = 0.2M
            };

            // Act
            var loggingBuilder = Logging.BuildCurrentLog(calculation);

            // Assert 
            Assert.Equal($"{DateTime.Now}, OperationType: CombinedWith, number A: 1, number B: 0.2, result: 0.2\n", loggingBuilder);
        }
    }
}