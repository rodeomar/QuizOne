using Microsoft.AspNetCore.Mvc;
using QuizOne.Db;

namespace QuizOne.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var quizzes = _context.Quizzes.ToList();
            return View(quizzes);
        }
    }
}
