using backend_quiz.DTOs;
using backend_quiz.Repositories.Interfaces;
using backend_quiz.Services.Interfaces;

namespace backend_quiz.Services.AuthService;

public class UserAnswerService : IUserAnswerService
{
    private readonly IUserAnswerRepository _userAnswerRepository;

    public UserAnswerService(IUserAnswerRepository userAnswerRepository)
    {
        _userAnswerRepository = userAnswerRepository;
    }

    public async Task<UserAnswerDto> UpdateUserAnswerAsync(int id, UpdateUserAnswerDto dto)
    {
        return await _userAnswerRepository.UpdateUserAnswerAsync(id, dto);
    }
}