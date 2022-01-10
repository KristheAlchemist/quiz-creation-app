using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class QuestionType
    {
        public int Id { get; set; }
        public string Choice { get; set; }
    }
}