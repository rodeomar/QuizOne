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
            List<Question> questions = _context.Questions.Where(question => question.QuizId == QuizId).ToList();
            List<int> questionIds = questions.Select(q => q.Id).ToList();
            List<Answer> answers = _context.Answers
                .Where(a => questionIds.Contains(a.QuestionId))
                .ToList();
            Quiz? quiz = _context.Quizzes.ToList().Find(qui => qui.Id == QuizId);


            return View(new StartViewModel() { Questions = questions, Answers = answers, Quiz = quiz });
        }


       [HttpPost] 
        public IActionResult SubmitQuiz(Dictionary<int, int> selectedAnswers)
        {
            int score = 0;

            foreach (var kvp in selectedAnswers)
            {
                int questionId = kvp.Key;
                int selectedAnswerId = kvp.Value;

                int correctAnswerId = _context.Answers
                    .Where(a => a.QuestionId == questionId && a.IsCorrect)
                    .Select(a => a.Id)
                    .FirstOrDefault();

                if (selectedAnswerId == correctAnswerId)
                {
                    score++;
                }
            }
            
            ViewBag.Score = score;
            ViewBag.TotalQuestions = selectedAnswers.Count();

            return View("QuizResult"); 
        }


        public IActionResult QuizResult(){


            return RedirectToAction("Index","Quiz");
        }
    }
}
