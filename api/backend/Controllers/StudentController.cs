using backend.Models;
using System.ComponentModel.DataAnnotations;
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

                var studentResponse = students.Select(student =>
                    new StudentResponse
                    {
                        Id = student.Id,
                        Name = student.Name,
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
                    Email = student.Email,
                };

                return new OkObjectResult(studentResponse);
            }



            catch (Exception e)
            {
                _logger.LogCritical($"SQL Read error. It is likely that there is no database connection established. ${e.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentRequest studentRequest)
        {
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(studentRequest, new ValidationContext(studentRequest), validationResults, true))
            {
                return new BadRequestObjectResult(validationResults);
            }

            var studentToAdd = new Student
            {
                Name = studentRequest.Name,
                Email = studentRequest.Email,
            };

            await _db.Students.AddAsync(studentToAdd);
            await _db.SaveChangesAsync();

            var addedStudent = await _db.Students
                .Include(s => s.StudentQuizzes)
                .SingleAsync(s => s.Id == studentToAdd.Id);

            return new CreatedResult("api/Students" + studentToAdd.Id, new StudentResponse(addedStudent));
        }
    }
}