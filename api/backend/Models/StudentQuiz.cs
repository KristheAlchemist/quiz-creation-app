namespace backend.Models
{
    public class StudentQuiz
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QuizId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
