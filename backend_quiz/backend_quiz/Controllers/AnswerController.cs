using System.Security.Claims;
using backend_quiz.DTOs;
using backend_quiz.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_quiz.Controllers;
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AnswerController :  ControllerBase
{
    private readonly IAnswerService _answerService;

    public AnswerController(IAnswerService answerService)
    {
        _answerService = answerService;
    }
    
    [HttpPost("{id}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<AnswerDto>> CreateAnswerAsync(int id,CreateAnswerDto dto)
    {
        var answer = await _answerService.CreateAnswerAsync(id,dto);
        return Ok(answer);
    }

    
    [HttpPatch("{id}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<AnswerDto>> UpdateAnswerAsync(int id, UpdateAnswerDto dto)
    {
        var answer = await _answerService.UpdateAnswerAsync(id, dto);
        return Ok(answer);
    }
    
    [HttpDelete("{id}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> DeleteAnswerAsync(int id)
    {
        var result = await _answerService.DeleteAnswerAsync(id);
        if (!result)
            return NotFound(new { message = "Answer not found or could not be deleted." });

        return Ok(true); 
    }

    
}