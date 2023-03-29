using CalculatorWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace CalculatorWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Calculation calculation)
        {
            if (ModelState.IsValid)
            {
                calculation.Result = CalculateResult(calculation);
            }
            
            return View(calculation);
        }

        private decimal CalculateResult(Calculation calculation)
        {
            var multiplyResult = Multiply(calculation.NumberA, calculation.NumberB);
            decimal result = 0;
            switch (calculation.Operation)
            {
                case Calculation.OperationType.CombinedWith:
                    result = multiplyResult;
                    break;
                case Calculation.OperationType.Either:
                    result = Add(calculation.NumberA, calculation.NumberB) - multiplyResult;
                    break;
            }
            return result;
        }

        private static decimal Add(decimal numberA, decimal numberB)
        {
            return numberA + numberB;
        }

        private decimal Multiply(decimal numberA, decimal numberB)
        {
            return numberA * numberB;
        }
    }
}
