using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Question
    {
        [Key]
        public long Id { get; set; }
        public string Text { get; set; }
        public Question(string text)
        {
            Text = text;
        }
    }
}
