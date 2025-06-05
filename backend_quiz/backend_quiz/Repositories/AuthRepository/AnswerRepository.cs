using AutoMapper;
using backend_quiz.Data;
using backend_quiz.Repositories.Interfaces;

namespace backend_quiz.Repositories.AuthRepository;

public class AnswerRepository :  IAnswerRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AnswerRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    
    
}