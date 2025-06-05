using backend_quiz.Authentication.Repositories;
using backend_quiz.Authentication.Services;
using backend_quiz.Repositories.AuthRepository;
using backend_quiz.Repositories.Interfaces;
using backend_quiz.Services.AuthService;
using backend_quiz.Services.Interface;
using backend_quiz.Services.Interfaces;

namespace backend_quiz.Configurations
{
    public static class DependencyInjection
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
        
            // Register Repositories
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();

            
            // Register Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IAnswerService, AnswerService>();



            
        }
    }
}