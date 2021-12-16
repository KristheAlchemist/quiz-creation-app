using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Quiz quiz = null;

            try
            {
                quiz = await _db.Quizzes.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }

            if (quiz == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(quiz);
        }
    }
}
