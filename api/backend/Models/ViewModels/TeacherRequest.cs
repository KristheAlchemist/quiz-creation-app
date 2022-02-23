using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class TeacherRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public ICollection<Quiz> Quizzes { get; set; }
    }
}