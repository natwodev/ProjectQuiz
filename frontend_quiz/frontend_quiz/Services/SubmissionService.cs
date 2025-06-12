using System.Net.Http.Json;
using frontend_quiz.DTOs;

namespace frontend_quiz.Services;

public class SubmissionService
{
    private readonly HttpClient _http;

    public SubmissionService(HttpClient http)
    {
        _http = http;
    }
    /*
    public async Task<HttpResponseMessage> CreateSubmissionAsync(int examId)
    {
        return await _http.PostAsync($"api/submission/{examId}", null);
    }*/
    public async Task<HttpResponseMessage> CreateSubmissionAsync(int examId)
    {
        return await _http.PostAsync($"api/submission/{examId}", null);
    }
    
    public async Task<SubmissionDto?> GetSubmissionByIdAsync(int id)
    {
        var submission = await _http.GetFromJsonAsync<SubmissionDto>($"api/submission/{id}");
        return submission;
    }
    
    public async Task<List<SubmissionDto>> GetAllSubmissionByUserIdAsync()
    {
        var submissions = await _http.GetFromJsonAsync<List<SubmissionDto>>("api/submission");
        return submissions ?? new List<SubmissionDto>();
    }
}