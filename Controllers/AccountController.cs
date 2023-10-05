using Microsoft.AspNetCore.Mvc;

namespace QuizOne.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
