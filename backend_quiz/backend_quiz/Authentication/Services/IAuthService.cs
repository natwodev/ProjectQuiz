
namespace backend_quiz.Authentication.Services;

public interface IAuthService
{
    Task<AuthResultDto> AuthenticateAsync(LoginModelDTO loginModel);
    Task LogoutAsync(string token);

}