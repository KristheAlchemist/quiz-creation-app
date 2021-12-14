using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Question question = null;

            try
            {
                question = await _db.Questions.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }

            if (question == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(question);
        }
    }
}
