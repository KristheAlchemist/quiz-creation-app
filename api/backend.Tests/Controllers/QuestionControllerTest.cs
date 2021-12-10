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
    public class QuestionControllerTest : IAsyncLifetime
    {

        private QuestionController testObject;
        private QuizCreationDbContext db;

        public async Task InitializeAsync()
        {
            db = await TestUtils.GetTestDbContext();
            testObject = new QuestionController(db, new Mock<ILogger<QuestionController>>().Object);
        }

        public async Task DisposeAsync()
        {
            await db.DisposeAsync();
        }

        public class GetQuestion : QuestionControllerTest
        {

            [Fact]
            public async void WhenDbConnection_ReturnsOkObjectContainingTest()
            {
                var response = await testObject.Get();

                response.Should().BeOfType<OkObjectResult>();
                var result = (response as OkObjectResult).Value as Question;
                result.Text.Should().Be(TestUtils.QUESTION_TEXT);
            }

            [Fact]
            public async void WhenNoQuestion_ReturnsNotFound()
            {
                db.Questions.Remove(db.Questions.First());
                await db.SaveChangesAsync();

                var response = await testObject.Get();

                response.Should().BeOfType<NotFoundResult>();
            }

            [Fact]
            public async void WhenAnErrorOccursUsingDataBase_ThrowsError()
            {
                var mockDb = new Mock<QuizCreationDbContext>();

                mockDb.Setup(x => x.Questions).Throws(new Exception("Something Broke"));

                var testObject = new QuestionController(mockDb.Object, new Mock<ILogger<QuestionController>>().Object);

                var exception = await Assert.ThrowsAsync<Exception>(() => testObject.Get());

                exception.Message.Should().Be("Something Broke");
            }
        }
    }
}
