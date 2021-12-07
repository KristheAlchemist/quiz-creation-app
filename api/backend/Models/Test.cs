using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Test
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public Test(string title)
        {
            Title = title;
        }
    }
}