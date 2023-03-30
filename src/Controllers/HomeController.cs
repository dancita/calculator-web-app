using CalculatorWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using CalculatorWebApp.ExtensionMethods;

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
                calculation.Result = Calculations.CalculateResult(calculation);
                Logging.LogCalculation(calculation);
            }
            else
            {
                calculation.Result = null;
            }
            
            return View(calculation);
        }
    }
}
