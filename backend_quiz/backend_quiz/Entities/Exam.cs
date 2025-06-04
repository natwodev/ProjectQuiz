using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_quiz.Entities;

public class Exam
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string? Title { get; set; }

    public ICollection<Question>? Questions { get; set; } 
    public ICollection<Submission>? Submissions { get; set; } 
    
    

}
