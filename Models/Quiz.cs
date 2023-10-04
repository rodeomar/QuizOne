namespace QuizOne.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatorUserID { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Question> Questions { get; set; }
        public List<Category> Categories { get; set; }
    }
}