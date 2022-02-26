using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [AllowAnonymous]
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuizzesController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<QuizController> _logger;

        public QuizzesController(QuizCreationDbContext db, ILogger<QuizController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var quizzes = await _db.Quizzes
                    .ToListAsync();

                var quizResponses = quizzes.Select(quiz =>
                    new QuizResponse
                    {
                        Id = quiz.Id,
                        Title = quiz.Title
                    }
                );

                return new OkObjectResult(quizResponses);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }
        }
    }

    [AllowAnonymous]
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<QuizController> _logger;

        public QuizController(QuizCreationDbContext db, ILogger<QuizController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                var quiz = await _db.Quizzes
                    .Include(q => q.QuizQuestions)
                    .ThenInclude(qq => qq.Question)
                    .Include(q => q.QuizQuestions)
                    .ThenInclude(qq => qq.Question)
                    .FirstOrDefaultAsync(q => q.Id == id);

                if (quiz == null)
                {
                    return new NotFoundResult();
                }

                var quizResponse = new QuizResponse
                {
                    Id = quiz.Id,
                    Title = quiz.Title,
                    Questions = quiz.QuizQuestions.Select(qq =>
                        new QuestionResponse
                        {
                            Id = qq.Question.Id,
                            Text = qq.Question.Text,
                            QuestionType = qq.Question.QuestionType
                        }
                    )
                };
                return new OkObjectResult(quizResponse);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }
        }
    }
}
