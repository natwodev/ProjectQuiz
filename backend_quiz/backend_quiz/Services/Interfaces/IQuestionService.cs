using backend_quiz.DTOs;

namespace backend_quiz.Services.Interfaces;

public interface IQuestionService
{
    Task<QuestionDto?> GetQuestionByIdAsync(int id);
    Task<QuestionDto> CreateQuestionAsync(int id, CreateQuestionDto dto);
    Task<IEnumerable<QuestionDto>> GetQuestionsByExamIdAsync(int id);
    Task<bool> DeleteQuestionAsync(int id);
}