using backend_quiz.Entities;
using Microsoft.AspNetCore.Identity;


// chắc chắn ApplicationUser và Employee ở đây

namespace backend_quiz.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>(); // thêm dòng này để lưu vào DB

            string[] roles = { "Admin", "Student" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            string adminEmail = "admin";
            string adminPassword = "admin";
            string fullname = "admin";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var user = new ApplicationUser
                {
                    FullName = fullname,
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");

                    await context.SaveChangesAsync();

                    Console.WriteLine("✅ Admin user đã được tạo.");
                }
                else
                {
                    Console.WriteLine("❌ Lỗi tạo user admin: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
            else
            {
                Console.WriteLine("ℹ️ Admin user đã tồn tại.");
            }
            string customerEmail = "2280602015";
            string customerPassword = "2280602015"; // Đặt password đủ mạnh
            string customerFullName = "Nguyễn Huỳnh Nam";

            var customerUser = await userManager.FindByEmailAsync(customerEmail);
            if (customerUser == null)
            {
                var user = new ApplicationUser
                {
                    FullName = customerFullName,
                    UserName = customerEmail,
                    Email = customerEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, customerPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Customer");
                    await context.SaveChangesAsync();
                    Console.WriteLine("✅ Customer user đã được tạo.");
                }
                else
                {
                    Console.WriteLine("❌ Lỗi tạo user Customer: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
            else
            {
                Console.WriteLine("ℹ️ Customer user đã tồn tại.");
            }
        }
    }
}
