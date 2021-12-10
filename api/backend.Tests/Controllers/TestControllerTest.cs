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
    public class TestControllerTest : IAsyncLifetime
    {

        private TestController testObject;
        private QuizCreationDbContext db;

        public async Task InitializeAsync()
        {
            db = await TestUtils.GetTestDbContext();
            testObject = new TestController(db, new Mock<ILogger<TestController>>().Object);
        }

        public async Task DisposeAsync()
        {
            await db.DisposeAsync();
        }

        public class GetTest : TestControllerTest
        {

            [Fact]
            public async void WhenDbConnection_ReturnsOkObjectContainingTest()
            {
                var response = await testObject.Get();

                response.Should().BeOfType<OkObjectResult>();
                var result = (response as OkObjectResult).Value as Test;
                result.Title.Should().Be(TestUtils.TEST_TITLE);
            }

            [Fact]
            public async void WhenNoTest_ReturnsNotFound()
            {
                db.Tests.Remove(db.Tests.First());
                await db.SaveChangesAsync();

                var response = await testObject.Get();

                response.Should().BeOfType<NotFoundResult>();
            }

            [Fact]
            public async void WhenAnErrorOccursUsingDataBase_ThrowsError()
            {
                var mockDb = new Mock<QuizCreationDbContext>();

                mockDb.Setup(x => x.Tests).Throws(new Exception("Something Broke"));

                var testObject = new TestController(mockDb.Object, new Mock<ILogger<TestController>>().Object);

                var exception = await Assert.ThrowsAsync<Exception>(() => testObject.Get());

                exception.Message.Should().Be("Something Broke");
            }
        }
    }
}
