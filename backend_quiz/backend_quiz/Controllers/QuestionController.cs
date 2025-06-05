using System.Security.Claims;
using backend_quiz.DTOs;
using backend_quiz.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_quiz.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }
    
    
    [HttpPost("{id}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<QuestionDto>> CreateExamAsync(int id,CreateQuestionDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized(new { message = "Token không hợp lệ!" });
        var question = await _questionService.CreateQuestionAsync(id, dto);
        return Ok(question);
    }
    
    
    
    [HttpGet("{id}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<QuestionDto>> GetQuestionByIdAsync(int id)
    {
        var question = await _questionService.GetQuestionByIdAsync(id);
        return Ok(question);
    }
    
    
    [HttpGet("{id}/Exam")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestionsByExamIdAsync(int id)
    {
        var exams = await _questionService.GetQuestionsByExamIdAsync(id);
        return Ok(exams);
    }

}