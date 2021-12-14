using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Choices
    {
        [Key]
        public string Text { get; set; }

        public Choices(string text)
        {
            Text = text;
        }

        public virtual Question Question { get; set; }
    }
}