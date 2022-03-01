using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class QuizRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
        public IEnumerable<QuestionRequest> Questions { get; set; }
    }

    public class QuestionRequest
    {
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }
        public string CorrectAnswer { get; set; }

        public IEnumerable<ChoiceRequest> Choices { get; set; }
    }

    public class ChoiceRequest
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }
    }
}