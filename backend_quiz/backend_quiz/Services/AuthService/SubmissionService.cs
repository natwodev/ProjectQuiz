using AutoMapper;
using backend_quiz.DTOs;
using backend_quiz.Repositories.Interfaces;
using backend_quiz.Services.Interfaces;

namespace backend_quiz.Services.AuthService;

public class SubmissionService : ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;
    private readonly IMapper _mapper;

    public SubmissionService(ISubmissionRepository submissionRepository, IMapper mapper)
    {
        _submissionRepository = submissionRepository;
        _mapper = mapper;
    }

    public async Task<SubmissionDto?> GetSubmissionByIdAsync(int id)
    {
        return await _submissionRepository.GetSubmissionByIdAsync(id);
    }

    public async Task<IEnumerable<SubmissionDto>> GetSubmissionsByUserIdAsync(string userId)
    {
        return await _submissionRepository.GetSubmissionsByUserIdAsync(userId);
    }

    public async Task<IEnumerable<SubmissionDto>> GetSubmissionsByExamIdAsync(int examId)
    {
        return await _submissionRepository.GetSubmissionsByExamIdAsync(examId);
    }

    public async Task<SubmissionDto> CreateSubmissionAsync(string userId,int id)
    {
        // Additional business logic can be added here
        // For example, validation, authorization checks, etc.
        return await _submissionRepository.CreateSubmissionAsync(userId,id);
    }

    public async Task<SubmissionDto> UpdateSubmissionAsync(int id, UpdateSubmissionDto dto)
    {
        // Additional business logic can be added here
        // For example, validation, authorization checks, etc.
        return await _submissionRepository.UpdateSubmissionAsync(id, dto);
    }

    public async Task<bool> DeleteSubmissionAsync(int id)
    {
        return await _submissionRepository.DeleteSubmissionAsync(id);
    }
}