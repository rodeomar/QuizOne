namespace QuizOne.Models
{
    public class QuizResultViewModel
    {
        public List<int> SelectedAnswers { get; set; }
        public List<Answer> CorrectAnswers { get; set; }
        public List<Question> Questions { get; set; }
        public int Score { get; set; }
    }
}
