using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentQuiz> StudentQuizzes { get; set; }
    }
}
