using backend_quiz.DTOs;

namespace backend_quiz.Services.Interfaces;

public interface IUserAnswerService
{
    Task<UserAnswerDto> UpdateUserAnswerAsync(int id, UpdateUserAnswerDto dto);
}