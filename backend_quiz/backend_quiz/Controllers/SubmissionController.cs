using System.Security.Claims;
using backend_quiz.DTOs;
using backend_quiz.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_quiz.Controllers;


[ApiController]
[Authorize]
[Route("api/[controller]")]
public class SubmissionController : ControllerBase
{
    private readonly ISubmissionService _submissionService;

    public SubmissionController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }
    
    [HttpGet]
    [Authorize(Policy = "StudentOnly")]
    public async Task<ActionResult<IEnumerable<ExamDto>>> GetAllExamsAsync()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized(new { message = "Token không hợp lệ!" });
        var submission = await _submissionService.GetSubmissionsByUserIdAsync(userId);
        return Ok(submission);
    }

    
    [HttpPost("{examId}")]
    [Authorize(Policy = "StudentOrAdmin")]
    public async Task<ActionResult<SubmissionDto>> CreateSubmissionAsync(int examId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized(new { message = "Token không hợp lệ!" });
        var question = await _submissionService.CreateSubmissionAsync(userId, examId);
        return Ok(question);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "StudentOnly")]
    public async Task<ActionResult<SubmissionDto>> GetSubmissionByIdAsync(int id)
    {
        var submission = await _submissionService.GetSubmissionByIdAsync(id);
        return Ok(submission);
    }
}


