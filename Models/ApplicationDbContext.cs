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
        }
    }
}
