using backend_quiz.DTOs;

namespace backend_quiz.Services.Interfaces;

public interface IAnswerService
{
    Task<AnswerDto> CreateAnswerAsync(int id, CreateAnswerDto dto);
    Task<AnswerDto> UpdateAnswerAsync(int id, UpdateAnswerDto dto);
    Task<bool> DeleteAnswerAsync(int id);
}