namespace backend_quiz.Authentication;

public class LoginModelDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }  // Lưu mật khẩu đã hash
    
}

