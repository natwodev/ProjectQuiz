
using Microsoft.AspNetCore.Identity;

namespace backend_quiz.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
}