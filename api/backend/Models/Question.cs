using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public int QuestionTypeId { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }

        public virtual QuestionType QuestionType { get; set; }
    }
}
