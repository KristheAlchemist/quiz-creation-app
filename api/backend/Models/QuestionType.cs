using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class QuestionType
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public QuestionType(string text)
        {
            Text = text;
        }
    }
}