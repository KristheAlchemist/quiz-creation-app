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
        public static readonly string USER_NAME = "Kris Robinson";
        public static readonly string TEST_TITLE = "Test 1";
        public static readonly string QUESTION_TEXT = "Why did the chicken cross the road?";
        public static readonly string QUESTION_TYPE = "MultipleChoice";

        public static async Task<QuizCreationDbContext> GetTestDbContext()
        {
            var db = new QuizCreationDbContext(CreateOptions());
            await db.Database.EnsureDeletedAsync();
            await db.Database.EnsureCreatedAsync();

            var user = new User(USER_NAME);
            db.Users.Add(user);

            var test = new Test(TEST_TITLE);
            db.Tests.Add(test);

            var question = new Question(QUESTION_TEXT, QUESTION_TYPE);
            db.Questions.Add(question);

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