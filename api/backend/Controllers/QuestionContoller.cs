using backend.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<QuestionsController> _logger;

        public QuestionsController(QuizCreationDbContext db, ILogger<QuestionsController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var questions = await _db.Questions
                    .ToListAsync();

                if (questions == null)
                {
                    return new NotFoundResult();
                }

                var questionsResponse = questions.Select(question =>
                    new QuestionResponse
                    {
                        Id = question.Id,
                        Text = question.Text,
                    }
                );

                return new OkObjectResult(questionsResponse);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(QuizCreationDbContext db, ILogger<QuestionController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var question = await _db.Questions
                    .Include(q => q.Choices)
                    .FirstOrDefaultAsync(q => q.Id == id);

                if (question == null)
                {
                    return new NotFoundResult();
                }

                var questionResponse = new QuestionResponse
                {
                    Id = question.Id,
                    Text = question.Text,
                    QuestionType = question.QuestionType,
                    Choices = question.Choices.Select(c =>
                        new ChoiceResponse
                        {
                            Id = c.Id,
                            Text = c.Text,
                            QuestionId = c.QuestionId
                        }),
                };

                return new OkObjectResult(questionResponse);
            }



            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }
        }
    }
}