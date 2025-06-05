namespace backend_quiz.DTOs;

public class AnswerDto
{
    public int AnswerId { get; set; }
    public int? QuestionId { get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
}

public class CreateAnswerDto
{
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
}

public class UpdateAnswerDto
{
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
} 