using backend_quiz.DTOs;
using backend_quiz.Entities;

namespace backend_quiz.Repositories.Interfaces;

public interface ISubmissionRepository
{
    Task<SubmissionDto?> GetSubmissionByIdAsync(int id);
    Task<IEnumerable<SubmissionDto>> GetSubmissionsByUserIdAsync(string userId);
    Task<IEnumerable<SubmissionDto>> GetSubmissionsByExamIdAsync(int examId);
    Task<SubmissionDto> CreateSubmissionAsync(string userId, int examId);
    Task<SubmissionDto> UpdateSubmissionAsync(int id, UpdateSubmissionDto dto);
    Task<bool> DeleteSubmissionAsync(int id);
    Task<Submission?> GetSubmissionEntityByIdAsync(int id);
}