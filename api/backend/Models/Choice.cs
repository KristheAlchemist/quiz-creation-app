using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Choice
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public Choice(string text)
        {
            Text = text;
        }
    }
}