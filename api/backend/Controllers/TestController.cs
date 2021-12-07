using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<TestController> _logger;

        public TestController(QuizCreationDbContext db, ILogger<TestController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Test? test = null;

            try
            {
                test = await _db.Tests.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }

            if (test == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(test);
        }
    }
}
