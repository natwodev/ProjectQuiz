namespace frontend_quiz.DTOs;

public class UserAnswerDto
{
    public int UserAnswerId { get; set; }
    public int SubmissionId { get; set; }
    public int QuestionId { get; set; }
    public int SelectedAnswerId { get; set; }
}

public class CreateUserAnswerDto
{
    public int QuestionId { get; set; }
    public int? SelectedAnswerId { get; set; }
}

public class UpdateUserAnswerDto
{
    public int SelectedAnswerId { get; set; }
} 