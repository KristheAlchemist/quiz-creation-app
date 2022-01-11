using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserQuiz> UserQuizzes { get; set; }
    }
}
