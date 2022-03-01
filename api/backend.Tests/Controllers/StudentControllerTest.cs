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
                result.Email.Should().Be(TestUtils.STUDENT_EMAIL);
            }

            [Fact]
            public async void WhenNoStudentExists_ReturnsNotFound()
            {
                var testId = 999999;
                var response = await testObject.GetById(testId);
                response.Should().BeOfType<NotFoundResult>();
            }
        }

        public class Post : StudentControllerTest
        {
            [Fact]
            public async void WhenNewStudentAdded_ReturnsOkObject()
            {
                var newStudent = new StudentRequest
                {
                    Name = "Mike Robinson",
                    Email = "mr@wwt.com",
                };
                var response = await testObject.Post(newStudent);
                var result = (response as CreatedResult).Value as StudentResponse;
                result.Id.Should().BeGreaterThan(1);
                result.Name.Should().Be(newStudent.Name);
                result.Email.Should().Be(newStudent.Email);
            }

            [Fact]
            public async void WhenRequestObjectIsInvalid_ReturnsBadRequest()
            {
                var newStudent = new StudentRequest();
                var response = await testObject.Post(newStudent);
                response.Should().BeOfType<BadRequestObjectResult>();
                var validationResults = ((response as BadRequestObjectResult).Value as IEnumerable<ValidationResult>);
                validationResults.Should().Contain(vr => vr.MemberNames.Contains("Name") && vr.ErrorMessage.Contains("required"));
            }
        }
    }
}