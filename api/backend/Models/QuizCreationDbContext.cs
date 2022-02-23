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

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<StudentQuiz> StudentQuizzes { get; set; }

        public virtual DbSet<Quiz> Quizzes { get; set; }

        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        // public virtual DbSet<Choice> Choices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<QuestionType>().HasData(
            //     new QuestionType { Id = 1, Choice = "ShortAnswer" },
            //     new QuestionType { Id = 2, Choice = "TrueFalse" },
            //     new QuestionType { Id = 3, Choice = "MultipleChoice" }
            // );
        }
    }
}