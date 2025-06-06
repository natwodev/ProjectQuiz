using AutoMapper;
using backend_quiz.Data;
using backend_quiz.DTOs;
using backend_quiz.Entities;
using backend_quiz.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_quiz.Repositories.AuthRepository;

public class SubmissionRepository : ISubmissionRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    
    public SubmissionRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SubmissionDto?> GetSubmissionByIdAsync(int id)
    {
        var submission = await _context.Submissions
            .Include(s => s.UserAnswers)
            .FirstOrDefaultAsync(s => s.SubmissionId == id);

        return submission != null ? _mapper.Map<SubmissionDto>(submission) : null;
    }

    public async Task<IEnumerable<SubmissionDto>> GetSubmissionsByUserIdAsync(string userId)
    {
        var submissions = await _context.Submissions
            .Include(s => s.UserAnswers)
            .Where(s => s.UserId == userId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<SubmissionDto>>(submissions);
    }

    public async Task<IEnumerable<SubmissionDto>> GetSubmissionsByExamIdAsync(int examId)
    {
        var submissions = await _context.Submissions
            .Include(s => s.UserAnswers)
            .Where(s => s.ExamId == examId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<SubmissionDto>>(submissions);
    }

    public async Task<SubmissionDto> CreateSubmissionAsync(string userId, int examId)
    {
        var exam = await _context.Exams
            .Include(e => e.Questions)
            .FirstOrDefaultAsync(e => e.ExamId == examId);

        if (exam == null)
            throw new ArgumentException("Exam not found");

        var submission = new Submission
        {
            ExamId = examId,
            UserId = userId,
            UserAnswers = exam.Questions.Select(q => new UserAnswer
            {
                QuestionId = q.Id,
                SelectedAnswerId = null // Chưa chọn đáp án
            }).ToList()
        };

        _context.Submissions.Add(submission);
        await _context.SaveChangesAsync();

        return await GetSubmissionByIdAsync(submission.SubmissionId)
               ?? throw new Exception("Failed to create submission");
    }


    public async Task<SubmissionDto> UpdateSubmissionAsync(int id, UpdateSubmissionDto dto)
    {
        var submission = await _context.Submissions
            .Include(s => s.UserAnswers)
            .FirstOrDefaultAsync(s => s.SubmissionId == id);
            
        if (submission == null)
            throw new ArgumentException("Submission not found");

        _mapper.Map(dto, submission);
        await _context.SaveChangesAsync();

        return await GetSubmissionByIdAsync(id) 
            ?? throw new Exception("Failed to update submission");
    }

    public async Task<bool> DeleteSubmissionAsync(int id)
    {
        var submission = await _context.Submissions.FindAsync(id);
        if (submission == null)
            return false;

        _context.Submissions.Remove(submission);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Submission?> GetSubmissionEntityByIdAsync(int id)
    {
        return await _context.Submissions
            .Include(s => s.UserAnswers)
            .FirstOrDefaultAsync(s => s.SubmissionId == id);
    }
}