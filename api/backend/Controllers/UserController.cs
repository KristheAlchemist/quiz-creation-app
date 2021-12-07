using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<UserController> _logger;

        public UserController(QuizCreationDbContext db, ILogger<UserController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            User? user = null;

            try
            {
                user = await _db.Users.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }

            if (user == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(user);
        }
    }
}
