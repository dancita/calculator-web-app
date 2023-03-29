using CalculatorWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Calculation calculation)
        {
            if (ModelState.IsValid)
            {
                calculation.Result = CalculateResult(calculation);
            }
            
            return View(calculation);
        }

        private static decimal CalculateResult(Calculation calculation)
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

        private static decimal Multiply(decimal numberA, decimal numberB)
        {
            return numberA * numberB;
        }
    }
}
