using System;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;
using backend.Models;
using backend.Tests.Utils;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace backend.Tests.Controllers
{
    public class QuizControllerTest : IAsyncLifetime
    {

        private QuizController testObject;
        private QuizCreationDbContext db;

        public async Task InitializeAsync()
        {
            db = await TestUtils.GetTestDbContext();
            testObject = new QuizController(db, new Mock<ILogger<QuizController>>().Object);
        }

        public async Task DisposeAsync()
        {
            await db.DisposeAsync();
        }

        public class GetTest : QuizControllerTest
        {

            [Fact]
            public async void WhenDbConnection_ReturnsOkObjectContainingTest()
            {
                var response = await testObject.Get();

                response.Should().BeOfType<OkObjectResult>();
                var result = (response as OkObjectResult).Value as Quiz;
                result.Title.Should().Be(TestUtils.QUIZ_TITLE);
            }

            [Fact]
            public async void WhenNoTest_ReturnsNotFound()
            {
                db.Quizzes.Remove(db.Quizzes.First());
                await db.SaveChangesAsync();

                var response = await testObject.Get();

                response.Should().BeOfType<NotFoundResult>();
            }

            [Fact]
            public async void WhenAnErrorOccursUsingDataBase_ThrowsError()
            {
                var mockDb = new Mock<QuizCreationDbContext>();

                mockDb.Setup(x => x.Quizzes).Throws(new Exception("Something Broke"));

                var quizObject = new QuizController(mockDb.Object, new Mock<ILogger<QuizController>>().Object);

                var exception = await Assert.ThrowsAsync<Exception>(() => quizObject.Get());

                exception.Message.Should().Be("Something Broke");
            }
        }
    }
}
