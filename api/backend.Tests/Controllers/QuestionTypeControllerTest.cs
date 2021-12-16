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
    public class QuestionTypeControllerTest : IAsyncLifetime
    {

        private QuestionTypeController testObject;
        private QuizCreationDbContext db;

        public async Task InitializeAsync()
        {
            db = await TestUtils.GetTestDbContext();
            testObject = new QuestionTypeController(db, new Mock<ILogger<QuestionTypeController>>().Object);
        }

        public async Task DisposeAsync()
        {
            await db.DisposeAsync();
        }

        public class GetTest : QuestionTypeControllerTest
        {

            [Fact]
            public async void WhenDbConnection_ReturnsOkObjectContainingTest()
            {
                var response = await testObject.Get();

                response.Should().BeOfType<OkObjectResult>();
                var result = (response as OkObjectResult).Value as QuestionType;
                result.Text.Should().Be(TestUtils.QUESTION_TYPE);
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

                var quizObject = new QuestionTypeController(mockDb.Object, new Mock<ILogger<QuestionTypeController>>().Object);

                var exception = await Assert.ThrowsAsync<Exception>(() => quizObject.Get());

                exception.Message.Should().Be("Something Broke");
            }
        }
    }
}
