using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Quiz
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        // public virtual ICollection<Question> Questions { get; set; }

        public Quiz(string title)
        {
            Title = title;
        }
    }
}