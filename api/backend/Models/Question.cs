using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Question
    {
        [Key]
        public long Id { get; set; }
        public string Text { get; set; }
        public string QuestionType { get; set; }
        public ICollection<Choices> Choices { get; set; }
        // Once I figure this part out, I can map the choices to the Question subcomponents.
        public string Answer { get; set; }

        public Question(string text)
        {
            Text = text;
        }

        public virtual Test Test { get; set; }
    }
}
