
namespace backend_quiz.Authentication.Services;

public interface IAuthService
{
    Task<AuthResultDto> AuthenticateAsync(LoginModelDto loginModel);
    Task LogoutAsync(string token);

}