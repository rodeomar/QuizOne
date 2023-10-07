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
            var quizResultViewModel = new QuizResultViewModel
            {
                SelectedAnswers = selectedAnswers.Values.ToList(),
                Questions = new List<Question>(),
                CorrectAnswers = new List<Answer>(),
                Score = 0
            };
            foreach (var kvp in selectedAnswers)
            {
                int questionId = kvp.Key;
                int selectedAnswerId = kvp.Value;

                var question = _context.Questions.Include(q => q.Answers)
                    .FirstOrDefault(q => q.Id == questionId);

                int correctAnswerId = question.Answers
                    .Where(a => a.IsCorrect && a.QuestionId == questionId)
                    .Select(a => a.Id)
                    .FirstOrDefault();

                quizResultViewModel.Questions.Add(question);

                if (selectedAnswerId == correctAnswerId)
                {
                    score++;
                }
                    quizResultViewModel.CorrectAnswers.Add(question.Answers.First(a => a.IsCorrect));
            }

            quizResultViewModel.Score = score;

            return View("QuizResult", quizResultViewModel);
        }



        public IActionResult QuizResult()
        {


            return RedirectToAction("Index", "Quiz");
        }
    }
}
