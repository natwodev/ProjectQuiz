using AutoMapper;
using backend_quiz.Data;
using backend_quiz.DTOs;
using backend_quiz.Entities;
using backend_quiz.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_quiz.Repositories.AuthRepository;

public class QuestionRepository :  IQuestionRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    
    public QuestionRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<QuestionDto?> GetQuestionByIdAsync(int id)
    {
        var question = await _context.Questions
            .Include(e => e.Answers)
            .FirstOrDefaultAsync(e => e.Id == id);

        return question != null ? _mapper.Map<QuestionDto>(question) : null;
    }
    
    public async Task<QuestionDto> CreateQuestionAsync(int id,CreateQuestionDto dto)
    {
        var question = _mapper.Map<Question>(dto);
        question.ExamId = id;
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        return await GetQuestionByIdAsync(question.Id) 
               ?? throw new Exception("Failed to create question");
    }
}