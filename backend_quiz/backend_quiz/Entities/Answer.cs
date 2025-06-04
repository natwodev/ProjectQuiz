using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_quiz.Entities;

public class Answer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AnswerId { get; set; }
    
    [ForeignKey("Question")]
    public int? QuestionId { get; set; }
    
    public Question? Question { get; set; } 
    
    [MaxLength(100)]
    public string Content { get; set; }
    
    public bool IsCorrect { get; set; }
}