namespace backend.Models
{
    public class TeacherResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<QuizResponse> Quizzes { get; set; }
    }
}