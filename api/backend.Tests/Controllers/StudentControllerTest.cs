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
    public class StudentControllerTest : IAsyncLifetime
    {

        private StudentController testObject;
        private QuizCreationDbContext db;

        public async Task InitializeAsync()
        {
            db = await TestUtils.GetTestDbContext();
            testObject = new StudentController(db, new Mock<ILogger<StudentController>>().Object);
        }

        public async Task DisposeAsync()
        {
            await db.DisposeAsync();
        }

        public class GetById : StudentControllerTest
        {
            [Fact]
            public async void WhenDbStudentExists_ReturnsOkObjectContainingStudent()
            {
                var testId = db.Students.First(s => s.Name == TestUtils.STUDENT_NAME).Id;
                var response = await testObject.GetById(testId);

                response.Should().BeOfType<OkObjectResult>();
                var result = (response as OkObjectResult).Value as StudentResponse;
                result.Name.Should().Be(TestUtils.STUDENT_NAME);
            }
        }

        [Fact]
        public async void WhenNoStudentExists_ReturnsNotFound()
        {
            var testId = 999999;
            var response = await testObject.GetById(testId);
            response.Should().BeOfType<NotFoundResult>();
        }
    }
}
