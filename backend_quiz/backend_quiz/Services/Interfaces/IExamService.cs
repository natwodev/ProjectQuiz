using backend_quiz.DTOs;

namespace backend_quiz.Services.Interfaces;

public interface IExamService
{
    Task<IEnumerable<ExamDto>> GetAllExamsAsync();
    Task<ExamDto?> GetExamByIdAsync(int id);
    Task<IEnumerable<ExamDto>> GetExamsByUserIdAsync(string userId);
    Task<ExamDto> CreateExamAsync(string id,CreateExamDto dto);
    Task<ExamDto> UpdateExamAsync(int id, UpdateExamDto dto);
    Task<bool> DeleteExamAsync(int id);
    Task<bool> DeleteAllExamsAsync();
    Task<ExamDto> AddQuestionToExamAsync(int examId, CreateQuestionDto questionDto);
    Task<ExamDto> RemoveQuestionFromExamAsync(int examId, int questionId);
} 