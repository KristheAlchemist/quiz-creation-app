using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoiceController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<ChoiceController> _logger;

        public ChoiceController(QuizCreationDbContext db, ILogger<ChoiceController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Choice choice = null;

            try
            {
                choice = await _db.Choices.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }

            if (choice == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(choice);
        }
    }
}
