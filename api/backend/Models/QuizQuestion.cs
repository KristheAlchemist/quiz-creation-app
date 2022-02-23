namespace backend.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public int QuestionId { get; set; }


        public virtual Quiz Quiz { get; set; }

        public virtual Question Question { get; set; }
    }
}
