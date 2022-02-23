using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<TeachersController> _logger;

        public TeachersController(QuizCreationDbContext db, ILogger<TeachersController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var teachers = await _db.Teachers
                    .ToListAsync();

                if (teachers == null)
                {
                    return new NotFoundResult();
                }

                var teacherResponse = teachers.Select(teacher =>
                    new TeacherResponse
                    {
                        Id = teacher.Id,
                        Name = teacher.Name,
                    }
                );

                return new OkObjectResult(teacherResponse);
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
    public class TeacherController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<StudentController> _logger;

        public TeacherController(QuizCreationDbContext db, ILogger<StudentController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var teacher = await _db.Teachers
                    .Include(t => t.Quizzes)
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (teacher == null)
                {
                    return new NotFoundResult();
                }

                var teacherResponse = new TeacherResponse
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                };

                return new OkObjectResult(teacherResponse);
            }



            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }
        }
    }
}