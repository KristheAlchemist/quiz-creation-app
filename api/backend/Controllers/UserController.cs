using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<UsersController> _logger;

        public UsersController(QuizCreationDbContext db, ILogger<UsersController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _db.Users
                    .ToListAsync();

                if (users == null)
                {
                    return new NotFoundResult();
                }

                var usersResponse = users.Select(user =>
                    new UserResponse
                    {
                        Id = user.Id,
                        Name = user.Name,
                    }
                );

                return new OkObjectResult(usersResponse);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }
        }
    }

    [AllowAnonymous]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _db.Users
                    .Include(u => u.UserQuizzes)
                    .ThenInclude(us => us.Quiz)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    return new NotFoundResult();
                }

                var userResponse = new UserResponse
                {
                    Id = user.Id,
                    Name = user.Name,
                };

                return new OkObjectResult(userResponse);
            }



            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }
        }
    }
}