using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_quiz.Entities;

public class Question
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey("Exam")]
    public int ExamId { get; set; }
    
    public Exam Exam { get; set; } 

    [MaxLength(100)]
    public string Content { get; set; } 

    public ICollection<Answer>? Answers { get; set; } 
}