using backend_quiz.DTOs;
using backend_quiz.Entities;

namespace backend_quiz.Repositories.Interfaces;

public interface IUserAnswerRepository
{
    Task<UserAnswerDto> UpdateUserAnswerAsync(int id, UpdateUserAnswerDto dto);
    Task<UserAnswer?> GetUserAnswerByIdAsync(int id);
}