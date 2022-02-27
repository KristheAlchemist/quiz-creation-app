using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class StudentRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public IEnumerable<StudentQuiz> StudentQuizzes { get; set; }
    }
}