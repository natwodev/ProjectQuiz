using System.Security.Claims;
using backend_quiz.DTOs;
using backend_quiz.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_quiz.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ExamController : ControllerBase
{
    private readonly IExamService _examService;

    public ExamController(IExamService examService)
    {
        _examService = examService;
    }
    
    
    [HttpPost]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<ExamDto>> CreateExamAsync(CreateExamDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized(new { message = "Token không hợp lệ!" });
        var exam = await _examService.CreateExamAsync(userId,dto);
        return Ok(exam);
    }
    
    
    [HttpGet]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<IEnumerable<ExamDto>>> GetAllExamsAsync()
    {
        var exams = await _examService.GetAllExamsAsync();
        return Ok(exams);
    }
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ExamDto>> GetExamByIdAsync(int id)
    {
        var exams = await _examService.GetExamByIdAsync(id);
        return Ok(exams);
    }
    
    
    [HttpGet("my-exam")]
    public async Task<ActionResult<IEnumerable<ExamDto>>> GetExamsByUserIdAsync()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized(new { message = "Token không hợp lệ!" });
        var exams = await _examService.GetExamsByUserIdAsync(userId);
        return Ok(exams);
    }

}