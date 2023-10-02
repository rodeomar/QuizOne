using QuizOne.User;
namespace QuizOne.Models
{
    public class QuizResult
    {
        public int Id { get; set; }
        public int QuizId { get; set; } 
        public int UserId { get; set; }
        public int Score { get; set; }
        public DateTime CompletionDate { get; set; }
        public Quiz Quiz { get; set; }
        public ApplicationUser User;

    }
}
