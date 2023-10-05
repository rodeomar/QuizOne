using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizOne.User;
using QuizOne.Models;

namespace QuizOne.Db
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
        public DbSet<QuizCategory> QuizCategory { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuizResult>()
                .HasKey(qr => qr.Id);

            modelBuilder.Entity<QuizResult>()
                .HasOne(qr => qr.User)
                .WithMany()
                .HasForeignKey(qr => qr.UserId);

            modelBuilder.Entity<QuizResult>()
                .HasOne(qr => qr.Quiz)
                .WithMany()
                .HasForeignKey(qr => qr.QuizId);

            modelBuilder.Entity<QuizCategory>()
                .HasKey(qc => new { qc.QuizId, qc.CategoryId });

            modelBuilder.Entity<QuizCategory>()
                .HasOne(qc => qc.Quiz)
                .WithMany(q => q.QuizCategories)
                .HasForeignKey(qc => qc.QuizId);

            modelBuilder.Entity<QuizCategory>()
                .HasOne(qc => qc.Category)
                .WithMany()
                .HasForeignKey(qc => qc.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Programming" },
                new Category { Id = 2, Name = "C#" }
            );

            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = 1,
                    Title = "C# Basics",
                    Description = "Test your knowledge of C# fundamentals.",
                    CreationDate = DateTime.Now
                }
            );

            modelBuilder.Entity<QuizCategory>().HasData(
                new QuizCategory { QuizId = 1, CategoryId = 1 },
                new QuizCategory { QuizId = 1, CategoryId = 2 }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, Text = "How many types of loops are in C#", QuizId = 1 },
                new Question { Id = 2, Text = "What is the purpose of the \"using\" statement in C#?", QuizId = 1 },
                new Question { Id = 3, Text = "What is a variable in C#?", QuizId = 1 },
                new Question { Id = 4, Text = "How do you declare a constant in C#?", QuizId = 1 },
                new Question { Id = 5, Text = "What is the difference between \"==\" and \"Equals\" in C#?", QuizId = 1 },
                new Question { Id = 6, Text = "What is the C# syntax for a for loop?", QuizId = 1 },
                new Question { Id = 7, Text = "What is the purpose of the \"Main\" method in a C# program?", QuizId = 1 },
                new Question { Id = 8, Text = "What is the C# syntax for defining a class?", QuizId = 1 },
                new Question { Id = 9, Text = "What is an object in C#?", QuizId = 1 },
                new Question { Id = 10, Text = "What is the difference between \"public\" and \"private\" access modifiers in C#?", QuizId = 1 }
            );

            modelBuilder.Entity<Answer>().HasData(
                new Answer { Id = 1, Text = "4", IsCorrect = true, QuestionId = 1 },
                new Answer { Id = 2, Text = "2", IsCorrect = false, QuestionId = 1 },
                new Answer { Id = 3, Text = "5", IsCorrect = false, QuestionId = 1 },
                new Answer { Id = 4, Text = "3", IsCorrect = false, QuestionId = 1 },
                new Answer { Id = 5, Text = "The \"using\" statement is used for including namespaces in your code.", IsCorrect = true, QuestionId = 2 },
                new Answer { Id = 6, Text = "The \"using\" statement is used for exception handling in C#.", IsCorrect = false, QuestionId = 2 },
                new Answer { Id = 7, Text = "The \"using\" statement is used for loop control in C#.", IsCorrect = false, QuestionId = 2 },
                new Answer { Id = 8, Text = "A variable in C# is a named storage location in memory.", IsCorrect = true, QuestionId = 3 },
                new Answer { Id = 9, Text = "A variable in C# cannot change its value once assigned.", IsCorrect = false, QuestionId = 3 },
                new Answer { Id = 10, Text = "A variable in C# does not have a data type.", IsCorrect = false, QuestionId = 3 },
                new Answer { Id = 11, Text = "To declare a constant in C#, use the \"const\" keyword.", IsCorrect = true, QuestionId = 4 },
                new Answer { Id = 12, Text = "To declare a constant in C#, use the \"var\" keyword.", IsCorrect = false, QuestionId = 4 },
                new Answer { Id = 13, Text = "To declare a constant in C#, use the \"let\" keyword.", IsCorrect = false, QuestionId = 4 },
                new Answer { Id = 14, Text = "\"==\" is used for comparing the reference of objects in memory.", IsCorrect = false, QuestionId = 5 },
                new Answer { Id = 15, Text = "\"==\" is used for comparing the values of two variables.", IsCorrect = true, QuestionId = 5 },
                new Answer { Id = 16, Text = "\"Equals\" is used for comparing strings in C#.", IsCorrect = false, QuestionId = 5 },
                new Answer { Id = 17, Text = "for (int i = 0; i < n; i++) { /* loop body */ }", IsCorrect = true, QuestionId = 6 },
                new Answer { Id = 18, Text = "for (int i = 0; i < n) { /* loop body */ }", IsCorrect = false, QuestionId = 6 },
                new Answer { Id = 19, Text = "for (i = 0; i < n; i++) { /* loop body */ }", IsCorrect = false, QuestionId = 6 },
                new Answer { Id = 20, Text = "The \"Main\" method is the entry point of a C# program.", IsCorrect = true, QuestionId = 7 },
                new Answer { Id = 21, Text = "The \"Main\" method is used for declaring global variables.", IsCorrect = false, QuestionId = 7 },
                new Answer { Id = 22, Text = "The \"Main\" method is used for defining classes in C#.", IsCorrect = false, QuestionId = 7 },
                new Answer { Id = 23, Text = "To define a class in C#, use the \"class\" keyword.", IsCorrect = true, QuestionId = 8 },
                new Answer { Id = 24, Text = "To define a class in C#, use the \"struct\" keyword.", IsCorrect = false, QuestionId = 8 },
                new Answer { Id = 25, Text = "To define a class in C#, use the \"interface\" keyword.", IsCorrect = false, QuestionId = 8 },
                new Answer { Id = 26, Text = "An object in C# is an instance of a class.", IsCorrect = true, QuestionId = 9 },
                new Answer { Id = 27, Text = "An object in C# is a static member of a class.", IsCorrect = false, QuestionId = 9 },
                new Answer { Id = 28, Text = "An object in C# is used for mathematical calculations.", IsCorrect = false, QuestionId = 9 },
                new Answer { Id = 29, Text = "\"public\" allows access from any class in any assembly.", IsCorrect = true, QuestionId = 10 },
                new Answer { Id = 30, Text = "\"private\" allows access only within the same class.", IsCorrect = true, QuestionId = 10 },
                new Answer { Id = 31, Text = "\"public\" and \"private\" access modifiers are not used in C#.", IsCorrect = false, QuestionId = 10 }
            );
        }
    }
}
