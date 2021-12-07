using System.Threading.Tasks;
using backend.Controllers;
using backend.Models;
using backend.Tests.Utils;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace backend.Tests.Models
{
    public class TestTest
    {
        [Fact]
        public void WhenTestConstructedWithTitleThenTitleIsSetCorrectly()
        {
            var expectedTitle = "Test 1";

            var result = new Test(expectedTitle);

            result.Title.Should().Be(expectedTitle);
        }
    }
}