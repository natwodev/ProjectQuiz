namespace frontend_quiz.Services;

public class AppState
{
    public bool IsAuthenticated { get; private set; }
    public bool IsAdmin { get; private set; }
    public bool IsStudent { get; private set; }

    public event Action? OnChange;

    public async Task SetStateAsync(AuthService authService)
    {
        IsAuthenticated = await authService.IsAuthenticated();
        IsAdmin = await authService.IsAdmin();
        IsStudent = await authService.IsStudent();
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}