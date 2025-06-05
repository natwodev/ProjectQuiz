using backend_quiz.DTOs;

namespace backend_quiz.Repositories.Interfaces;

public interface IQuestionRepository
{
    Task<QuestionDto?> GetQuestionByIdAsync(int id);
    Task<QuestionDto> CreateQuestionAsync(int id, CreateQuestionDto dto);
}