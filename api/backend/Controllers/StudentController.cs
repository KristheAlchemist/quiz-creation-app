using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(QuizCreationDbContext db, ILogger<StudentsController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var students = await _db.Students
                    .ToListAsync();

                if (students == null)
                {
                    return new NotFoundResult();
                }

                var studentResponse = students.Select(user =>
                    new StudentResponse
                    {
                        Id = user.Id,
                        Name = user.Name,
                    }
                );

                return new OkObjectResult(studentResponse);
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
    public class StudentController : ControllerBase
    {
        private readonly QuizCreationDbContext _db;
        private readonly ILogger<StudentController> _logger;

        public StudentController(QuizCreationDbContext db, ILogger<StudentController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var student = await _db.Students
                    .Include(u => u.StudentQuizzes)
                    .ThenInclude(us => us.Quiz)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (student == null)
                {
                    return new NotFoundResult();
                }

                var studentResponse = new StudentResponse
                {
                    Id = student.Id,
                    Name = student.Name,
                };

                return new OkObjectResult(studentResponse);
            }



            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }
        }
    }
}