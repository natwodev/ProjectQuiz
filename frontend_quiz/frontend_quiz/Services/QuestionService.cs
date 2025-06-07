using System.Net.Http.Json;
using frontend_quiz.DTOs;

namespace frontend_quiz.Services;

public class QuestionService
{
    private readonly HttpClient _http;

    public QuestionService(HttpClient http)
    {
        _http = http;
    }
    
    public async Task<HttpResponseMessage> CreateQuestionAsync(int examId, CreateQuestionDto newQuestion)
    {
        return await _http.PostAsJsonAsync($"api/question/{examId}", newQuestion);
    }

}