using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Teacher : User
    {
        public int TeacherId { get; set; }
    }
}
