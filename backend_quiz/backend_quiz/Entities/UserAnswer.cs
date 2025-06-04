namespace backend_quiz.Entities;

public class UserAnswer
{
    public int UserAnswerId { get; set; }
    public int SubmissionId { get; set; }
    public Submission Submission { get; set; } = null!;
    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;
    public int SelectedAnswerId { get; set; }
    public Answer SelectedAnswer { get; set; } = null!;
}