using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<UserQuiz> UserQuizzes { get; set; }
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}