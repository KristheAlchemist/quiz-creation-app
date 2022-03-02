namespace backend.Models
{

    public class QuizResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<QuestionResponse> Questions { get; set; }

        public QuizResponse() { }
        public QuizResponse(Quiz quiz)
        {
            Id = quiz.Id;
            Title = quiz.Title;
        }
    }
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }
        public IEnumerable<ChoiceResponse> Choices { get; set; }

        public QuestionResponse() { }
        public QuestionResponse(Question question)
        {
            Id = question.Id;
            Text = question.Text;
            Choices = question.Choices.Select(choice =>
                new ChoiceResponse
                {
                    Id = choice.Id,
                    Text = choice.Text,

                });
        }
    }

    public class ChoiceResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
    }
}