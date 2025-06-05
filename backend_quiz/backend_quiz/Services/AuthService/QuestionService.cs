using AutoMapper;
using backend_quiz.DTOs;
using backend_quiz.Repositories.Interfaces;
using backend_quiz.Services.Interfaces;

namespace backend_quiz.Services.AuthService;

public class QuestionService :  IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<QuestionDto?> GetQuestionByIdAsync(int id)
    {
        return await _questionRepository.GetQuestionByIdAsync(id);
    }
    public async Task<QuestionDto> CreateQuestionAsync(int id,CreateQuestionDto dto)
    {
        return await _questionRepository.CreateQuestionAsync(id,dto);
    }
    
    public async Task<IEnumerable<QuestionDto>> GetQuestionsByExamIdAsync(int id)
    {
        return await _questionRepository.GetQuestionsByExamIdAsync(id);
    }
    
}