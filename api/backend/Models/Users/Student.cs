using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Student : User
    {
        public int TeacherId { get; set; }
    }
}
