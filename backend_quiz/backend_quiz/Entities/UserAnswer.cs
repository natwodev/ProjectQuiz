using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_quiz.Entities;

public class UserAnswer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserAnswerId { get; set; }

    [ForeignKey("Submission")]
    public int SubmissionId { get; set; }
    
    public Submission? Submission { get; set; } 
    
    [ForeignKey("Question")]
    public int QuestionId { get; set; }
    
    public Question? Question { get; set; } 
    
    [ForeignKey("SelectedAnswer")]
    public int SelectedAnswerId { get; set; }
    
    public Answer? SelectedAnswer { get; set; } 
}