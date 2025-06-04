using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_quiz.Entities;

public class Submission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SubmissionId { get; set; }
    
    [ForeignKey("Exam")]
    public int? ExamId { get; set; }
    
    public Exam? Exam { get; set; } 
    
    [ForeignKey("ApplicationUser")]
    public string? UserId { get; set; }
    
    public ApplicationUser? ApplicationUser { get; set; } 
    
    public ICollection<UserAnswer>? UserAnswers { get; set; } 
}
