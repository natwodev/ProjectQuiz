using AutoMapper;
using backend_quiz.Data;
using backend_quiz.DTOs;
using backend_quiz.Entities;
using backend_quiz.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_quiz.Repositories.AuthRepository;

public class ExamRepository : IExamRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ExamRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ExamDto>> GetAllExamsAsync()
    {
        var exams = await _context.Exams
            .Include(e => e.Questions)
                .ThenInclude(q => q.Answers)
            .Include(e => e.Submissions)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ExamDto>>(exams);
    }

    public async Task<ExamDto?> GetExamByIdAsync(int id)
    {
        var exam = await _context.Exams
            .Include(e => e.Questions)
                .ThenInclude(q => q.Answers)
            .Include(e => e.Submissions)
            .FirstOrDefaultAsync(e => e.ExamId == id);

        return exam != null ? _mapper.Map<ExamDto>(exam) : null;
    }

    public async Task<Exam?> GetExamEntityByIdAsync(int id)
    {
        return await _context.Exams
            .Include(e => e.Questions)
                .ThenInclude(q => q.Answers)
            .Include(e => e.Submissions)
            .FirstOrDefaultAsync(e => e.ExamId == id);
    }

    public async Task<IEnumerable<ExamDto>> GetExamsByUserIdAsync(string userId)
    {
        var exams = await _context.Exams
            .Include(e => e.Questions)
                .ThenInclude(q => q.Answers)
            .Include(e => e.Submissions)
            .Where(e => e.UserId == userId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ExamDto>>(exams);
    }

    public async Task<ExamDto> CreateExamAsync(string id,CreateExamDto dto)
    {
        var exam = _mapper.Map<Exam>(dto);
        exam.UserId = id;
        _context.Exams.Add(exam);
        await _context.SaveChangesAsync();

        return await GetExamByIdAsync(exam.ExamId) 
            ?? throw new Exception("Failed to create exam");
    }

    public async Task<ExamDto> UpdateExamAsync(int id, UpdateExamDto dto)
    {
        var exam = await _context.Exams.FindAsync(id);
        if (exam == null)
            throw new ArgumentException("Exam not found");

        _mapper.Map(dto, exam);
        await _context.SaveChangesAsync();

        return await GetExamByIdAsync(id) 
            ?? throw new Exception("Failed to update exam");
    }

    public async Task<bool> DeleteExamAsync(int id)
    {
        var exam = await _context.Exams.FindAsync(id);
        if (exam == null)
            return false;

        _context.Exams.Remove(exam);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAllExamsAsync()
    {
        var exams = await _context.Exams.ToListAsync();
        if (!exams.Any())
            return false;

        _context.Exams.RemoveRange(exams);
        await _context.SaveChangesAsync();
        return true;
    }
} 