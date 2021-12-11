using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Question
    {
        [Key]
        public long Id { get; set; }
        public string Text { get; set; }
        public string? QuestionType { get; set; }
        public string? Answer { get; set; }
        // public ICollection<string>? Choices { get; set; }
        public string? UsersAnswer { get; set; }

        public Question(string text, string questionType)
        {
            Text = text;
            QuestionType = questionType;
        }

        public virtual Test? Test { get; set; }
    }
}