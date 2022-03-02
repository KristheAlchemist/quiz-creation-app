using backend.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
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
                    .ThenInclude(q => q.Choices)
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
                            QuestionType = qq.Question.QuestionType,
                            Choices = qq.Question.Choices.Select(c =>
                               new ChoiceResponse
                               {
                                   Id = c.Id,
                                   Text = c.Text,
                                   QuestionId = c.QuestionId
                               }
                           )
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuizRequest quizRequest)
        {
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(quizRequest, new ValidationContext(quizRequest), validationResults, true))
            {
                return new BadRequestObjectResult(validationResults);
            }

            var quizToAdd = new Quiz
            {
                Title = quizRequest.Title,
                // QuizQuestions = quizRequest.Questions.Select(qr =>
                //     new Question
                //     {
                //         Text = qr.Text,
                //         QuestionType = qr.QuestionType,
                //         Choices = qr.Choices.Select(cr =>
                //             new Choice
                //             {
                //                 Text = cr.Text,
                //                 QuestionId = cr.QuestionId,
                //             }),
                //         CorrectAnswer = qr.CorrectAnswer,
                //     }
                // ),
            };

            await _db.Quizzes.AddAsync(quizToAdd);
            await _db.SaveChangesAsync();

            var addedQuiz = await _db.Quizzes
            .Include(s => s.QuizQuestions)
            .ThenInclude(qq => qq.Question)
            .ThenInclude(q => q.Choices)
            .SingleAsync(s => s.Id == quizToAdd.Id);

            return new CreatedResult("api/Quizzes" + quizToAdd.Id, new QuizResponse(addedQuiz));
        }

    }
}
