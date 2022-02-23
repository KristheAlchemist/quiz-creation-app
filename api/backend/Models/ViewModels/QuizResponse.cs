namespace backend.Models
{

    public class QuizResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<QuestionResponse> Questions { get; set; }
        public IEnumerable<StudentResponse> Students { get; set; }
    }
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}