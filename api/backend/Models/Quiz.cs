namespace backend.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<StudentQuiz> StudentQuizzes { get; set; }
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}