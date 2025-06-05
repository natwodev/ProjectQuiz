using AutoMapper;
using backend_quiz.DTOs;
using backend_quiz.Repositories.Interfaces;
using backend_quiz.Services.Interfaces;

namespace backend_quiz.Services.AuthService;

public class AnswerService : IAnswerService
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }
    
    public async Task<AnswerDto> CreateAnswerAsync(int id,CreateAnswerDto dto)
    {
        return await _answerRepository.CreateAnswerAsync(id, dto);
    }

    public async Task<AnswerDto> UpdateAnswerAsync(int id, UpdateAnswerDto dto)
    {
        return await _answerRepository.UpdateAnswerAsync(id, dto);
    }
    
    public async Task<bool> DeleteAnswerAsync(int id)
    {
        var answer = await _answerRepository.GetAnswerEntityByIdAsync(id);

        return await _answerRepository.DeleteAnswerAsync(id);
    }
}