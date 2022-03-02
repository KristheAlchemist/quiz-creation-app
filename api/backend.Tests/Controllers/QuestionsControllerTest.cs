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
    public class QuestionsControllerTest : IAsyncLifetime
    {

        private QuestionsController testObject;
        private QuizCreationDbContext db;

        public async Task InitializeAsync()
        {
            db = await TestUtils.GetTestDbContext();
            testObject = new QuestionsController(db, new Mock<ILogger<QuestionsController>>().Object);
        }

        public async Task DisposeAsync()
        {
            await db.DisposeAsync();
        }

        public class Get : QuestionsControllerTest
        {
            [Fact]
            public async void WhenQuestionsExist_ReturnsOkObjectContainingListOfQuestions()
            {
                var response = await testObject.GetAll();
                response.Should().BeOfType<OkObjectResult>();

                var QuestionsResultList = (response as OkObjectResult).Value as IEnumerable<QuestionResponse>;
                QuestionsResultList.Count().Should().Be(db.Questions.Count());

                var question = QuestionsResultList.First(qr => qr.Text == TestUtils.QUESTION_TEXT);
                question.Text.Should().Be(TestUtils.QUESTION_TEXT);
            }

            [Fact]
            public async void WhenNoQuestions_ReturnsEmptyList()
            {
                db.Questions.RemoveRange(db.Questions);
                await db.SaveChangesAsync();
                var response = await testObject.GetAll();
                response.Should().BeOfType<OkObjectResult>();
                var result = (response as OkObjectResult).Value as IEnumerable<QuestionResponse>;
                result.Any().Should().BeFalse();
            }

            [Fact]
            public async void WhenAnErrorOccursUsingDataBase_ThrowsError()
            {
                var mockDb = new Mock<QuizCreationDbContext>();

                mockDb.Setup(x => x.Questions).Throws(new Exception("Something Broke"));

                var testObject = new QuestionsController(mockDb.Object, new Mock<ILogger<QuestionsController>>().Object);

                var exception = await Assert.ThrowsAsync<Exception>(() => testObject.GetAll());

                exception.Message.Should().Be("Something Broke");
            }
        }
    }
}