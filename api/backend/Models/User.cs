using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }
    }
}
