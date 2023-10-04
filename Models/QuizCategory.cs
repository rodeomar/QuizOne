namespace QuizOne.Models
{
    public class QuizCategory
    {
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
