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
    public class StudentsControllerTest : IAsyncLifetime
    {

        private StudentsController testObject;
        private QuizCreationDbContext db;

        public async Task InitializeAsync()
        {
            db = await TestUtils.GetTestDbContext();
            testObject = new StudentsController(db, new Mock<ILogger<StudentsController>>().Object);
        }

        public async Task DisposeAsync()
        {
            await db.DisposeAsync();
        }

        public class Get : StudentsControllerTest
        {
            [Fact]
            public async void WhenStudentsExist_ReturnsOkObjectContainingListOfStudents()
            {
                var response = await testObject.GetAll();
                response.Should().BeOfType<OkObjectResult>();

                var StudentsResultList = (response as OkObjectResult).Value as IEnumerable<StudentResponse>;
                StudentsResultList.Count().Should().Be(db.Students.Count());

                var quiz = StudentsResultList.First(qr => qr.Name == TestUtils.STUDENT_NAME);
                quiz.Name.Should().Be(TestUtils.STUDENT_NAME);
            }

            [Fact]
            public async void WhenNoStudents_ReturnsEmptyList()
            {
                db.Students.RemoveRange(db.Students);
                await db.SaveChangesAsync();
                var response = await testObject.GetAll();
                response.Should().BeOfType<OkObjectResult>();
                var result = (response as OkObjectResult).Value as IEnumerable<StudentResponse>;
                result.Any().Should().BeFalse();
            }

            [Fact]
            public async void WhenAnErrorOccursUsingDataBase_ThrowsError()
            {
                var mockDb = new Mock<QuizCreationDbContext>();

                mockDb.Setup(x => x.Students).Throws(new Exception("Something Broke"));

                var testObject = new StudentsController(mockDb.Object, new Mock<ILogger<StudentsController>>().Object);

                var exception = await Assert.ThrowsAsync<Exception>(() => testObject.GetAll());

                exception.Message.Should().Be("Something Broke");
            }
        }
    }
}