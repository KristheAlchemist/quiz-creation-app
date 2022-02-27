using System;
using System.Collections.Generic;
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

        public class GetById : QuizControllerTest
        {
            [Fact]
            public async void WhenDbQuizExists_ReturnsOkObjectContainingQuiz()
            {
                var testId = db.Quizzes.First(q => q.Title == TestUtils.QUIZ_TITLE).Id;
                var response = await testObject.GetById(testId);

                response.Should().BeOfType<OkObjectResult>();
                var result = (response as OkObjectResult).Value as QuizResponse;
                result.Title.Should().Be(TestUtils.QUIZ_TITLE);
            }
        }

        [Fact]
        public async void WhenNoQuizExists_ReturnsNotFound()
        {
            var testId = 999999;
            var response = await testObject.GetById(testId);
            response.Should().BeOfType<NotFoundResult>();
        }
    }
}
