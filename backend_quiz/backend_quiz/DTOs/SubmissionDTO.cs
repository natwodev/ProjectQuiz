namespace backend_quiz.DTOs;

public class SubmissionDto
{
    public int SubmissionId { get; set; }
    public string Title { get; set; }
    public int? ExamId { get; set; }
    public string? UserId { get; set; }
    public ICollection<UserAnswerDto>? UserAnswers { get; set; }
}

public class CreateSubmissionDto
{
    public ICollection<CreateUserAnswerDto>? UserAnswers { get; set; }
}

public class UpdateSubmissionDto
{
    public int SubmissionId { get; set; }
    public int? ExamId { get; set; }
    public string? UserId { get; set; }
    public ICollection<UpdateUserAnswerDto>? UserAnswers { get; set; }
} 