using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionTypeController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<QuestionTypeController> _logger;

        public QuestionTypeController(QuizCreationDbContext db, ILogger<QuestionTypeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            QuestionType questionType = null;

            try
            {
                questionType = await _db.QuestionTypes.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }

            if (questionType == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(questionType);
        }
    }
}