using CalculatorWebApp.Models;
using Microsoft.AspNetCore.Mvc;

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
            calculation.Result = calculation.FirstNumber + calculation.SecondNumber;
            return View(calculation);
        }
    }
}
