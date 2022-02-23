using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}