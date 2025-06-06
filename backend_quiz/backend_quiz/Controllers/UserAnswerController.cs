using backend_quiz.DTOs;
using backend_quiz.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_quiz.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserAnswerController : ControllerBase
{
    private readonly IUserAnswerService _userAnswerService;

    public UserAnswerController(IUserAnswerService userAnswerService)
    {
        _userAnswerService = userAnswerService;
    }

    [HttpPatch("{id}")]
    [Authorize(Policy = "StudentOnly")]
    public async Task<ActionResult<UserAnswerDto>> UpdateUserAnswer(int id, UpdateUserAnswerDto dto)
    {
        var result = await _userAnswerService.UpdateUserAnswerAsync(id, dto);
        return Ok(result);
    }
} 