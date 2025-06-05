namespace backend_quiz.DTOs;

public class SubmissionDto
{
    public int SubmissionId { get; set; }
    public int? ExamId { get; set; }
    public string? UserId { get; set; }
    // Assuming UserAnswerDTO exists
    public ICollection<UserAnswerDto>? UserAnswers { get; set; }
}

public class CreateSubmissionDto
{
    public int? ExamId { get; set; }
    public string? UserId { get; set; }
    // Assuming CreateUserAnswerDTO exists for creating related user answers
    public ICollection<CreateUserAnswerDto>? UserAnswers { get; set; }
}

public class UpdateSubmissionDto
{
    public int SubmissionId { get; set; }
    public int? ExamId { get; set; }
    public string? UserId { get; set; }
    // Assuming UpdateUserAnswerDTO exists for updating related user answers
    public ICollection<UpdateUserAnswerDto>? UserAnswers { get; set; }
} 