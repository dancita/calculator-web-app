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
            if (ModelState.IsValid)
            {
                calculation.Result = calculation.NumberA + calculation.NumberB;
            }
            
            return View(calculation);
        }
    }
}
