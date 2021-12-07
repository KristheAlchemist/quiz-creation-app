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
    public class UserControllerTest : IAsyncLifetime
    {

        private UserController testObject;
        private QuizCreationDbContext db;

        public async Task InitializeAsync()
        {
            db = await TestUtils.GetTestDbContext();
            testObject = new UserController(db, new Mock<ILogger<UserController>>().Object);
        }

        public async Task DisposeAsync()
        {
            await db.DisposeAsync();
        }

        public class GetUser : UserControllerTest
        {

            [Fact]
            public async void WhenDbConnection_ReturnsOkObjectContainingUser()
            {
                var response = await testObject.Get();

                response.Should().BeOfType<OkObjectResult>();
                var result = (response as OkObjectResult).Value as User;
                result.Name.Should().Be(TestUtils.USER_NAME);
            }

            [Fact]
            public async void WhenNoProfile_ReturnsNotFound()
            {
                db.Users.Remove(db.Users.First());
                await db.SaveChangesAsync();

                var request = TestUtils.CreateMockRequest("GET");

                var response = await testObject.Get();

                response.Should().BeOfType<NotFoundResult>();
            }

            [Fact]
            public async void WhenAnErrorOccursUsingDataBase_ThrowsError()
            {
                var mockDb = new Mock<QuizCreationDbContext>();

                mockDb.Setup(x => x.Users).Throws(new Exception("Something Broke"));

                var testObject = new UserController(mockDb.Object, new Mock<ILogger<UserController>>().Object);

                var exception = await Assert.ThrowsAsync<Exception>(() => testObject.Get());

                exception.Message.Should().Be("Something Broke");
            }
        }
    }
}
