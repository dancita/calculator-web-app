using CalculatorWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new Calculation());
        }

        [HttpPost]
        public IActionResult Index(Calculation calculation)
        {
            calculation.Result = calculation.NumbersList?.Sum();
            return View(calculation);
        }
    }
}
