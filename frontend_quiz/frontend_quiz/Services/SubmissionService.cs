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
    public async Task<int> CreateSubmissionAsync(int examId)
    {
        var response = await _http.PostAsync($"api/submission/{examId}", null);
        response.EnsureSuccessStatusCode();
        var submissionId = await response.Content.ReadFromJsonAsync<int>();
        return submissionId;
    }


    
    public async Task<SubmissionDto?> GetSubmissionByIdAsync(int id)
    {
        var submission = await _http.GetFromJsonAsync<SubmissionDto>($"api/submission/{id}");
        return submission;
    }
}