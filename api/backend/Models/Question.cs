namespace backend.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public QuestionType QuestionType { get; set; }

        // public virtual ICollection<Choice> Choices { get; set; }
    }
}
