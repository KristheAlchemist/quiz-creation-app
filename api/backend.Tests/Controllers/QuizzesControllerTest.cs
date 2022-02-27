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
    public class QuizzesControllerTest : IAsyncLifetime
    {

        private QuizzesController testObject;
        private QuizCreationDbContext db;

        public async Task InitializeAsync()
        {
            db = await TestUtils.GetTestDbContext();
            testObject = new QuizzesController(db, new Mock<ILogger<QuizController>>().Object);
        }

        public async Task DisposeAsync()
        {
            await db.DisposeAsync();
        }

        public class Get : QuizzesControllerTest
        {
            [Fact]
            public async void WhenQuizzesExist_ReturnsOkObjectContainingListOfQuizzes()
            {
                var response = await testObject.GetAll();
                response.Should().BeOfType<OkObjectResult>();

                var QuizzesResultList = (response as OkObjectResult).Value as IEnumerable<QuizResponse>;
                QuizzesResultList.Count().Should().Be(db.Quizzes.Count());

                var quiz = QuizzesResultList.First(qr => qr.Title == TestUtils.QUIZ_TITLE);
                quiz.Title.Should().Be(TestUtils.QUIZ_TITLE);
            }

            [Fact]
            public async void WhenNoQuizzes_ReturnsEmptyList()
            {
                db.Quizzes.RemoveRange(db.Quizzes);
                await db.SaveChangesAsync();
                var response = await testObject.GetAll();
                response.Should().BeOfType<OkObjectResult>();
                var result = (response as OkObjectResult).Value as IEnumerable<QuizResponse>;
                result.Any().Should().BeFalse();
            }

            [Fact]
            public async void WhenAnErrorOccursUsingDataBase_ThrowsError()
            {
                var mockDb = new Mock<QuizCreationDbContext>();

                mockDb.Setup(x => x.Quizzes).Throws(new Exception("Something Broke"));

                var testObject = new QuizzesController(mockDb.Object, new Mock<ILogger<QuizController>>().Object);

                var exception = await Assert.ThrowsAsync<Exception>(() => testObject.GetAll());

                exception.Message.Should().Be("Something Broke");
            }
        }
    }
}