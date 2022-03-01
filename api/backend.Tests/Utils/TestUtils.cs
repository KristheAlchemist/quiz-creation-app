using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;

namespace backend.Tests.Utils
{
    public static class TestUtils
    {
        public static readonly string TEACHER_NAME = "Mr. Robinson";
        public static readonly string STUDENT_NAME = "Kris Robinson";
        public static readonly string STUDENT_EMAIL = "kris@wwt.com";
        public static readonly string QUIZ_TITLE = "Quiz 1";
        public static readonly string QUESTION_TEXT = "Why did the chicken cross the road?";
        public static readonly string QUESTION_TYPE = "ShortAnswer";
        public static readonly string CORRECT_ANSWER = "To get to the other side.";

        public static async Task<QuizCreationDbContext> GetTestDbContext()
        {
            var db = new QuizCreationDbContext(CreateOptions());
            await db.Database.EnsureDeletedAsync();
            await db.Database.EnsureCreatedAsync();

            var student = new Student { Name = STUDENT_NAME };
            db.Students.Add(student);

            var quiz = new Quiz { Title = QUIZ_TITLE };
            db.Quizzes.Add(quiz);

            var question = new Question { Text = QUESTION_TEXT };
            db.Questions.Add(question);

            var questionType = new Question { Text = QUESTION_TYPE };
            db.Questions.Add(questionType);

            var correctAnswer = new Question { Text = CORRECT_ANSWER };
            db.Questions.Add(correctAnswer);

            await db.SaveChangesAsync();

            return db;
        }

        private static DbContextOptions<QuizCreationDbContext> CreateOptions()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            var builder = new DbContextOptionsBuilder<QuizCreationDbContext>();
            builder.UseSqlite(connection);

            builder.ConfigureWarnings(x => x.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.AmbientTransactionWarning));

            return builder.Options;
        }
    }
}