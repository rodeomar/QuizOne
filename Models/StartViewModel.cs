namespace QuizOne.Models;
public class StartViewModel
{
    public List<Question> Questions { get; set; }
    public List<Answer> Answers { get; set; }
    public Quiz Quiz { get; set; }
}