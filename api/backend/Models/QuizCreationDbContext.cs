using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace backend.Models
{
    public class QuizCreationDbContext : DbContext
    {
        public QuizCreationDbContext() { }

        public QuizCreationDbContext(DbContextOptions<QuizCreationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserQuiz> UserQuizzes { get; set; }

        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<QuestionType> QuestionTypes { get; set; }

        public virtual DbSet<Choice> Choices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserQuizzes)
                .WithOne(q => q.User);

            modelBuilder.Entity<QuestionType>().HasData(
                new QuestionType { Id = 1, Choice = "ShortAnswer" },
                new QuestionType { Id = 2, Choice = "TrueFalse" },
                new QuestionType { Id = 3, Choice = "MultipleChoice" }
            );
        }
    }
}