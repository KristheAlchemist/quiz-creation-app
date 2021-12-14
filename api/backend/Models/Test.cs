using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Test
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public Test(string title)
        {
            Title = title;
        }
        public virtual User User { get; set; }
    }
}