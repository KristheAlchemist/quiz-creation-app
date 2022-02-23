namespace backend.Models
{
    public class StudentAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int QuestionId { get; set; }
        public int StudentQuizId { get; set; }
    }
}