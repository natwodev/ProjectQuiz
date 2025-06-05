using backend_quiz.DTOs;
using backend_quiz.Entities;

namespace backend_quiz.Repositories.Interfaces;

public interface IQuestionRepository
{
    Task<QuestionDto?> GetQuestionByIdAsync(int id);
    Task<QuestionDto> CreateQuestionAsync(int id, CreateQuestionDto dto);
    Task<List<QuestionDto>> GetQuestionsByExamIdAsync(int examId);
    Task<bool> DeleteQuestionAsync(int id);
    Task<Question?> GetQuestionEntityByIdAsync(int id);
}