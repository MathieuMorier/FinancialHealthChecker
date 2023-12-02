using Microsoft.AspNetCore.Mvc;

namespace FinancialHealthChecker.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Quiz()
        {
            return View();
        }
    }
}
