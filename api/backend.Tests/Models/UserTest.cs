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
    public class UserTest
    {
        [Fact]
        public void WhenUserConstructedWithNameThenNameIsSetCorrectly()
        {
            var expectedName = "Kris R.";

            var result = new User(expectedName);

            result.Name.Should().Be(expectedName);
        }
    }
}