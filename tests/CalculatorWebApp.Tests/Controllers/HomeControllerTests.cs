using CalculatorWebApp.Controllers;
using CalculatorWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CalculatorWebApp.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Theory]
        [InlineData(0.1, 0.2, 0.02)]
        [InlineData(1, 0.2, 0.2)]
        [InlineData(0.5, 0.5, 0.25)]
        [InlineData(0.888, 0.2, 0.1776)]
        [InlineData(0, 0.29, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(0.9999999999, 0.2, 0.19999999998)]
        public void Index_ViewData_ValidInput_OperationCombinedWith_ReturnsAsExpected(decimal numberA, decimal numberB, decimal result)
        {
            // Arrange
            var controller = new HomeController();
            var calculation = new Calculation()
            {
                NumberA = numberA,
                NumberB = numberB,
                Operation = Calculation.OperationType.CombinedWith                
            };

            // Act
            var viewResult = controller.Index(calculation) as ViewResult;

            // Assert
            Assert.NotNull(viewResult);
            Assert.NotNull(viewResult.ViewData.Model);
            var calculationResult = (Calculation)viewResult.ViewData.Model;
            Assert.Equal(numberA, calculationResult.NumberA);
            Assert.Equal(numberB, calculationResult.NumberB);
            Assert.Equal(Calculation.OperationType.CombinedWith, calculationResult.Operation);
            Assert.Equal(result, calculationResult.Result);
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
        public void Index_ViewData_ValidInput_OperationEither_ReturnsAsExpected(decimal numberA, decimal numberB, decimal result)
        {
            // Arrange
            var controller = new HomeController();
            var calculation = new Calculation()
            {
                NumberA = numberA,
                NumberB = numberB,
                Operation = Calculation.OperationType.Either
            };

            // Act
            var viewResult = controller.Index(calculation) as ViewResult;

            // Assert
            Assert.NotNull(viewResult);
            Assert.NotNull(viewResult.ViewData.Model);
            var calculationResult = (Calculation)viewResult.ViewData.Model;
            Assert.Equal(numberA, calculationResult.NumberA);
            Assert.Equal(numberB, calculationResult.NumberB);
            Assert.Equal(Calculation.OperationType.Either, calculationResult.Operation);
            Assert.Equal(result, calculationResult.Result);
        }

        [Theory]
        [InlineData(Calculation.OperationType.CombinedWith)]
        [InlineData(Calculation.OperationType.Either)]
        public void Index_ViewData_InvalidInput_ReturnsAsExpected(Calculation.OperationType operationType)
        {
            // Arrange
            var controller = new HomeController();
            var calculation = new Calculation()
            {
                NumberA = 0.1M,
                NumberB = 0.2M,
                Operation = operationType
            };
            controller.ModelState.AddModelError("ValidationError", "Number must be between 0 and 1");

            // Act
            var viewResult = controller.Index(calculation) as ViewResult;

            // Assert
            Assert.NotNull(viewResult);
            Assert.NotNull(viewResult.ViewData.Model);
            var calculationResult = (Calculation)viewResult.ViewData.Model;
            Assert.Equal(0.1M, calculationResult.NumberA);
            Assert.Equal(0.2M, calculationResult.NumberB);
            Assert.Equal(Calculation.OperationType.CombinedWith, calculationResult.Operation);
            Assert.Null(calculationResult.Result);
        }
    }
}