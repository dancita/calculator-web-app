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

        private long CalculateResult(Calculation calculation)
        {
            var multiplyResult = Multiply(calculation.NumberA, calculation.NumberB);
            long result = 0;
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

        private long Add(long numberA, long numberB)
        {
            return numberA + numberB;
        }

        private long Multiply(long numberA, long numberB)
        {
            return numberA * numberB;
        }
    }
}
