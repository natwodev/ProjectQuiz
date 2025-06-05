using Microsoft.AspNetCore.Authorization;

namespace backend_quiz.Configurations
{
    public static class AuthorizationPolicies
    {
       // string[] roles = { "Admin", "Seller", "Customer", "Shipper", "Support" };

        public static void AddCustomPolicies(AuthorizationOptions options)
        {
            options.AddPolicy("AdminOnly", policy =>
                policy.RequireRole("Admin"));
            
            options.AddPolicy("StudentOnly", policy =>
                policy.RequireRole("Student"));
            
            options.AddPolicy("StudentOrAdmin", policy =>
                policy.RequireRole("Student","Admin"));
        }
    }
}