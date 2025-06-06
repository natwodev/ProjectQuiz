using AutoMapper;
using backend_quiz.Data;
using backend_quiz.DTOs;
using backend_quiz.Entities;
using backend_quiz.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_quiz.Repositories.AuthRepository;

public class UserAnswerRepository : IUserAnswerRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    
    public UserAnswerRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<UserAnswer?> GetUserAnswerByIdAsync(int id)
    {
        return await _context.UserAnswers
            .FirstOrDefaultAsync(ua => ua.UserAnswerId == id);
    }
    
    public async Task<UserAnswerDto> UpdateUserAnswerAsync(int id, UpdateUserAnswerDto dto)
    {
        var userAnswer = await _context.UserAnswers.FindAsync(id);
        if (userAnswer == null)
            throw new ArgumentException("UserAnswer not found");

        userAnswer.SelectedAnswerId = dto.SelectedAnswerId;
        await _context.SaveChangesAsync();

        return _mapper.Map<UserAnswerDto>(userAnswer);
    }
}