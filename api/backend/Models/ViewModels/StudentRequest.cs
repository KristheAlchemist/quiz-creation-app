using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class StudentRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public ICollection<StudentQuiz> StudentQuizzes { get; set; }
    }
}