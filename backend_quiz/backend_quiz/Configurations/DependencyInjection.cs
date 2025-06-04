using backend_quiz.Authentication.Repositories;
using backend_quiz.Authentication.Services;
using backend_quiz.Repository.AuthRepository;
using backend_quiz.Repository.Interface;
using backend_quiz.Service.AuthService;
using backend_quiz.Service.Interface;

namespace backend_quiz.Configurations
{
    public static class DependencyInjection
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
        
            // Register Repositories
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            
            // Register Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();


            
        }
    }
}