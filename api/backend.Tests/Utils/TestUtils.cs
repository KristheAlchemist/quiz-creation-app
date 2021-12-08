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

        public static Mock<HttpRequest> CreateMockRequest(string method, object body = null, Dictionary<string, string> querystring = null)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            var json = JsonConvert.SerializeObject(body);
            sw.Write(json);
            sw.Flush();
            ms.Position = 0;
            var mockRequest = new Mock<HttpRequest>();
            var mockHttpContext = new Mock<HttpContext>();
            var mockHttpResponse = new Mock<HttpResponse>();
            var mockHttpHeaders = new Mock<IHeaderDictionary>();
            mockRequest.Setup(x => x.HttpContext).Returns(mockHttpContext.Object);
            mockHttpContext.Setup(x => x.Response).Returns(mockHttpResponse.Object);
            mockHttpResponse.Setup(x => x.Headers).Returns(mockHttpHeaders.Object);

            if (body != null)
            {
                mockRequest.Setup(x => x.Body).Returns(ms);
            }

            if (querystring != null)
            {
                foreach (var item in querystring)
                {
                    mockRequest.Setup(x => x.Query[item.Key]).Returns(item.Value);
                }
            }

            mockRequest.Setup(y => y.Method).Returns(method);

            return mockRequest;
        }

        public static async Task<QuizCreationDbContext> GetTestDbContext()
        {
            var db = new QuizCreationDbContext(CreateOptions());
            await db.Database.EnsureDeletedAsync();
            await db.Database.EnsureCreatedAsync();

            var user = new User(USER_NAME);
            db.Users.Add(user);

            var test = new Test(TEST_TITLE);
            db.Tests.Add(test);

            var question = new Question(QUESTION_TEXT);
            db.Tests.Add(test);

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