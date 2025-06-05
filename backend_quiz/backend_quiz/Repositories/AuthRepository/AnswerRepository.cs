using AutoMapper;
using backend_quiz.Data;
using backend_quiz.DTOs;
using backend_quiz.Entities;
using backend_quiz.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<Answer?> GetAnswerEntityByIdAsync(int id)
    {
        return await _context.Answers
            .FirstOrDefaultAsync(a => a.AnswerId == id);
    }
    
    public async Task<AnswerDto?> GetAnswerByIdAsync(int id)
    {
        var exam = await _context.Answers
            .FirstOrDefaultAsync(a => a.AnswerId == id);

        return exam != null ? _mapper.Map<AnswerDto>(exam) : null;
    }
    
    public async Task<AnswerDto> CreateAnswerAsync(int id,CreateAnswerDto dto)
    {
        var answer = _mapper.Map<Answer>(dto);
        answer.QuestionId = id;
        _context.Answers.Add(answer);
        await _context.SaveChangesAsync();

        return await GetAnswerByIdAsync(answer.AnswerId) 
               ?? throw new Exception("Failed to create answer");
    }

    public async Task<AnswerDto> UpdateAnswerAsync(int id, UpdateAnswerDto dto)
    {
        var answer = await _context.Answers.FindAsync(id);
        if (answer == null)
            throw new ArgumentException("Exam not found");

        _mapper.Map(dto, answer);
        await _context.SaveChangesAsync();

        return await GetAnswerByIdAsync(id) 
               ?? throw new Exception("Failed to update answer");
    }
    
    public async Task<bool> DeleteAnswerAsync(int id)
    {
        var answer = await _context.Answers.FindAsync(id);
        if (answer == null)
            return false;

        _context.Answers.Remove(answer);
        await _context.SaveChangesAsync();
        return true;
    }
    
}