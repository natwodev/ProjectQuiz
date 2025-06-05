using backend_quiz.DTOs;
using backend_quiz.Entities;

namespace backend_quiz.Repositories.Interfaces;

public interface IAnswerRepository
{
    Task<AnswerDto> CreateAnswerAsync(int id, CreateAnswerDto dto);
    Task<AnswerDto> UpdateAnswerAsync(int id, UpdateAnswerDto dto);
    Task<bool> DeleteAnswerAsync(int id);
    Task<Answer?> GetAnswerEntityByIdAsync(int id);
}