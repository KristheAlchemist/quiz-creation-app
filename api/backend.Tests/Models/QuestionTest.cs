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
    public class QuestionTest
    {
        [Fact]
        public void WhenQuestionConstructedWithTitleThenTitleIsSetCorrectly()
        {
            var expectedText = "Why did the chicken cross the road?";
            var questionType = "MultilpleChoice";

            var result = new Question(expectedText, questionType);

            result.Text.Should().Be(expectedText);
        }
    }
}