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
    
    public async Task<Question?> GetQuestionEntityByIdAsync(int id)
    {
        return await _context.Questions
            .Include(q => q.Answers)
            .FirstOrDefaultAsync(q => q.Id == id);
    }
    
    public async Task<QuestionDto> CreateQuestionAsync(int examId, CreateQuestionDto dto)
    {
        var question = new Question
        {
            Content = dto.Content,
            ExamId = examId,
            Answers = dto.Answers?.Select(a => new Answer
            {
                Content = a.Content,
                IsCorrect = a.IsCorrect
            }).ToList()
        };

        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        return await GetQuestionByIdAsync(question.Id)
               ?? throw new Exception("Failed to create question");
    }

    public async Task<List<QuestionDto>> GetQuestionsByExamIdAsync(int examId)
    {
        var questions = await _context.Questions
            .Include(q => q.Answers)
            .Where(q => q.ExamId == examId)
            .ToListAsync();

        return _mapper.Map<List<QuestionDto>>(questions);
    }
    public async Task<bool> DeleteQuestionAsync(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null)
            return false;

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
        return true;
    }


}