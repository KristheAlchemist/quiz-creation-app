using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class UserQuiz
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }

        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
        public virtual User User { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
