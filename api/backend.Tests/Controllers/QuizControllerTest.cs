using System;
using System.ComponentModel.DataAnnotations;
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

            [Fact]
            public async void WhenNoQuizExists_ReturnsNotFound()
            {
                var testId = 999999;
                var response = await testObject.GetById(testId);
                response.Should().BeOfType<NotFoundResult>();
            }
        }

        public class Post : QuizControllerTest
        {
            [Fact]
            public async void WhenNewQuizAdded_ReturnsOkObject()
            {
                var newQuiz = new QuizRequest
                {
                    Title = "Kris Robinson",
                };
                var response = await testObject.Post(newQuiz);
                var result = (response as CreatedResult).Value as QuizResponse;
                result.Id.Should().BeGreaterThan(1);
                result.Title.Should().Be(newQuiz.Title);
            }

            [Fact]
            public async void WhenRequestObjectIsInvalid_ReturnsBadRequest()
            {
                var newQuiz = new QuizRequest();
                var response = await testObject.Post(newQuiz);
                response.Should().BeOfType<BadRequestObjectResult>();
                var validationResults = ((response as BadRequestObjectResult).Value as IEnumerable<ValidationResult>);
                validationResults.Should().Contain(vr => vr.MemberNames.Contains("Title") && vr.ErrorMessage.Contains("required"));
            }
        }
    }
}
