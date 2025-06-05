using AutoMapper;
using backend_quiz.DTOs;
using backend_quiz.Entities;
using backend_quiz.Repositories.Interfaces;
using backend_quiz.Services.Interfaces;

namespace backend_quiz.Services.AuthService;

public class ExamService : IExamService
{
    private readonly IExamRepository _examRepository;
    private readonly IMapper _mapper;

    public ExamService(IExamRepository examRepository, IMapper mapper)
    {
        _examRepository = examRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ExamDto>> GetAllExamsAsync()
    {
        return await _examRepository.GetAllExamsAsync();
    }

    public async Task<ExamDto?> GetExamByIdAsync(int id)
    {
        return await _examRepository.GetExamByIdAsync(id);
    }

    public async Task<IEnumerable<ExamDto>> GetExamsByUserIdAsync(string userId)
    {
        return await _examRepository.GetExamsByUserIdAsync(userId);
    }

    public async Task<ExamDto> CreateExamAsync(string id,CreateExamDto dto)
    {
        // Additional business logic can be added here
        // For example, validation, authorization checks, etc.
        return await _examRepository.CreateExamAsync(id,dto);
    }

    public async Task<ExamDto> UpdateExamAsync(int id, UpdateExamDto dto)
    {
        // Additional business logic can be added here
        // For example, validation, authorization checks, etc.
        return await _examRepository.UpdateExamAsync(id, dto);
    }

    public async Task<bool> DeleteExamAsync(int id)
    {
        var exam = await _examRepository.GetExamEntityByIdAsync(id);
        if (exam?.Submissions?.Any() == true)
        {
            throw new InvalidOperationException("Cannot delete exam with existing submissions");
        }
        
        return await _examRepository.DeleteExamAsync(id);
    }

    public async Task<bool> DeleteAllExamsAsync()
    {
        // Additional business logic can be added here
        // For example, checking if any exams have submissions
        var exams = await _examRepository.GetAllExamsAsync();
        /*
        if (exams.Any(e => e.Submissions?.Any() == true))
        {
            throw new InvalidOperationException("Cannot delete exams with existing submissions");
        }
        
        */
        return await _examRepository.DeleteAllExamsAsync();
    }

    public async Task<ExamDto> AddQuestionToExamAsync(int examId, CreateQuestionDto questionDto)
    {
        var exam = await _examRepository.GetExamEntityByIdAsync(examId);
        if (exam == null)
            throw new ArgumentException("Exam not found");

        var question = _mapper.Map<Question>(questionDto);
        exam.Questions ??= new List<Question>();
        exam.Questions.Add(question);

        await _examRepository.UpdateExamAsync(examId, _mapper.Map<UpdateExamDto>(exam));
        return await _examRepository.GetExamByIdAsync(examId) 
            ?? throw new Exception("Failed to add question to exam");
    }

    public async Task<ExamDto> RemoveQuestionFromExamAsync(int examId, int questionId)
    {
        var exam = await _examRepository.GetExamEntityByIdAsync(examId);
        if (exam == null)
            throw new ArgumentException("Exam not found");

        var question = exam.Questions?.FirstOrDefault(q => q.Id == questionId);
        if (question == null)
            throw new ArgumentException("Question not found in exam");

        exam.Questions?.Remove(question);

        await _examRepository.UpdateExamAsync(examId, _mapper.Map<UpdateExamDto>(exam));
        return await _examRepository.GetExamByIdAsync(examId) 
            ?? throw new Exception("Failed to remove question from exam");
    }
} 