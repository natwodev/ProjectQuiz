using backend_quiz.Entities;

namespace backend_quiz.DTOs;

public class ExamDto
{
    public int ExamId { get; set; }
    
    public string Title { get; set; }

    public string? UserId { get; set; }
    
    public ICollection<QuestionDto>? Questions { get; set; } 

}

public class CreateExamDto
{
    public string Title { get; set; }

    public string? UserId { get; set; }
}

public class UpdateExamDto
{
    public string Title { get; set; }
    
}