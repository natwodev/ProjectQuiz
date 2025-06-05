using backend_quiz.Entities;

namespace backend_quiz.DTOs;

public class QuestionDto
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public string Content { get; set; }
    public ICollection<AnswerDto>? Answers { get; set; }
}

public class CreateQuestionDto
{
   // public int ExamId { get; set; }
    public string Content { get; set; }
    public ICollection<CreateAnswerDto>? Answers { get; set; }
}

public class UpdateQuestionDto
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public string Content { get; set; }
    public ICollection<UpdateAnswerDto>? Answers { get; set; }
}