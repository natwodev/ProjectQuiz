using backend_quiz.DTOs;
using backend_quiz.Entities;

namespace backend_quiz.Repositories.Interfaces;

public interface IExamRepository
{
    Task<IEnumerable<ExamDto>> GetAllExamsAsync();
    Task<ExamDto?> GetExamByIdAsync(int id);
    Task<Exam?> GetExamEntityByIdAsync(int id);
    Task<IEnumerable<ExamDto>> GetExamsByUserIdAsync(string userId);
    Task<ExamDto> CreateExamAsync(string id, CreateExamDto dto);
    Task<ExamDto> UpdateExamAsync(int id, UpdateExamDto dto);
    Task<bool> DeleteExamAsync(int id);
    Task<bool> DeleteAllExamsAsync();
} 