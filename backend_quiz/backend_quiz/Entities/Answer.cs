namespace backend_quiz.Entities;

public class Answer
{
    public int AnswerId { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;
    public string Content { get; set; } = null!;
    public bool IsCorrect { get; set; }
}