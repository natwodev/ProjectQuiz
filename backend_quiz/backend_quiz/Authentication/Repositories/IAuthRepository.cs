using backend_quiz.Entities;

namespace backend_quiz.Authentication.Repositories
{
    public interface IAuthRepository
    {
        // Method to get user by ID
        Task<ApplicationUser?> GetUserByUsernameAsync(string username);
        // Method to get permissions by user ID
    }
}