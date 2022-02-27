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

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<StudentQuiz> StudentQuizzes { get; set; }

        public virtual DbSet<Quiz> Quizzes { get; set; }

        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Choice> Choices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}