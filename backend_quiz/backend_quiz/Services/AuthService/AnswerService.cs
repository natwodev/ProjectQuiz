using AutoMapper;
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
    
    
}