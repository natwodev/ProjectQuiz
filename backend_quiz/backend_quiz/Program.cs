using backend_quiz.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Đọc cấu hình từ appsettings.json
var configuration = builder.Configuration;

// Đăng ký dịch vụ
builder.Services.ConfigureServices(configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await backend_quiz.Data.SeedData.InitializeAsync(services);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();



// Bật logging chi tiết
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// ✅ Gọi ConfigureMiddleware() (đã bao gồm kiểm tra token)
app.ConfigureMiddleware();

//app.MapHub<backend_quiz.Hubs.NotificationHub>("/notificationHub");

app.Run();
