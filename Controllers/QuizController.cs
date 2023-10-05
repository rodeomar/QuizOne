using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizOne.Db;
using QuizOne.Models;
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
            return View(_context);
        }

        public IActionResult Start(int QuizId)
        {
            List<Question> questions = _context.Questions.Include(q => q.QuizId == QuizId).ToList();
            List<int> questionIds = questions.Select(q => q.Id).ToList();
            List<Answer> answers = _context.Answers
                .Where(a => questionIds.Contains(a.QuestionId))
                .ToList();
            Quiz? quiz = _context.Quizzes.Find(QuizId);


            return View(new { Question = questions, Answer = answers, Quiz = quiz});
        }

    }
}
