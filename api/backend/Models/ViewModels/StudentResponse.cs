using System.Collections.Generic;

namespace backend.Models
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<StudentQuizResponse> StudentQuizzes { get; set; }

        public StudentResponse() { }
        public StudentResponse(Student student)
        {
            Id = student.Id;
            Name = student.Name;
        }
    }

    public class StudentQuizResponse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QuizId { get; set; }
    }
}