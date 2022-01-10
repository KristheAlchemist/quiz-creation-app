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

        public virtual DbSet<Quiz> Quizzes { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<QuestionType> QuestionTypes { get; set; }

        // public virtual DbSet<Choice> Choices { get; set; }

        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Kris Robinson",
                }
            );

            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = 1,
                    Title = "Quiz 1",
                }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Text = "Why did the chicken cross the road?",
                    CorrectAnswer = "To get to the other side.",
                    QuestionTypeId = 3,
                }
            );

            modelBuilder.Entity<QuestionType>().HasData(
                new QuestionType { Id = 1, Choice = "ShortAnswer" },
                new QuestionType { Id = 2, Choice = "TrueFalse" },
                new QuestionType { Id = 3, Choice = "MultipleChoice" }
            );
        }
    }
}