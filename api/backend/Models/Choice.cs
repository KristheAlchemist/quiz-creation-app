using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Choice
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}