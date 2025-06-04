namespace backend_quiz.Entities;

public class Submission
{
    public int SubmissionId { get; set; }
    public int UserId { get; set; }
    public ApplicationUser User { get; set; } 
    public int ExamId { get; set; }
    public Exam Exam { get; set; } 
    public DateTime SubmittedAt { get; set; }
    public float Score { get; set; }

    public ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
}
