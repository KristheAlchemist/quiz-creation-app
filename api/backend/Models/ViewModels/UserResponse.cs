using System.Collections.Generic;

namespace backend.Models
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<UserQuizResponse> UserQuizzes { get; set; }
    }

    public class UserQuizResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public virtual IEnumerable<UserAnswerResponse> UserAnswers { get; set; }
    }

    public class UserAnswerResponse
    {
        public int Id { get; set; }
        public string Answer { get; set; }
    }
}