using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_quiz.Entities;

public class Exam
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ExamId { get; set; }
    
    [StringLength(100)]
    public string Title { get; set; }

    [ForeignKey("ApplicationUser")]
    public string? UserId { get; set; }
    
    public ApplicationUser? ApplicationUser { get; set; } 
    
    public ICollection<Question>? Questions { get; set; } 
    public ICollection<Submission>? Submissions { get; set; } 
    
    

}
