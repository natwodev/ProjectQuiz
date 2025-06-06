using backend_quiz.DTOs;

namespace backend_quiz.Services.Interfaces;

public interface ISubmissionService
{
    Task<SubmissionDto?> GetSubmissionByIdAsync(int id);
    Task<IEnumerable<SubmissionDto>> GetSubmissionsByUserIdAsync(string userId);
    Task<IEnumerable<SubmissionDto>> GetSubmissionsByExamIdAsync(int examId);
    Task<SubmissionDto> CreateSubmissionAsync(string userId, int id);
    Task<SubmissionDto> UpdateSubmissionAsync(int id, UpdateSubmissionDto dto);
    Task<bool> DeleteSubmissionAsync(int id);
}