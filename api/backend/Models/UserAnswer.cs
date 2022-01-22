using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int QuestionId { get; set; }
        public int UserQuizId { get; set; }
    }
}