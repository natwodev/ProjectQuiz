using System.Net.Http.Json;
using frontend_quiz.DTOs;

namespace frontend_quiz.Services;

public class ExamService
{
    private readonly HttpClient _http;

    public ExamService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ExamDto>> GetAllExamsAsync()
    {
        var exams = await _http.GetFromJsonAsync<List<ExamDto>>("api/exam");
        return exams ?? new List<ExamDto>();
    }
    
    public async Task<ExamDto?> GetExamByIdAsync(int id)
    {
        var exam = await _http.GetFromJsonAsync<ExamDto>($"api/exam/{id}");
        return exam;
    }
    
    public async Task<HttpResponseMessage> CreateExamAsync(CreateExamDto newProduct)
    {
        return await _http.PostAsJsonAsync("api/exam", newProduct);
    }
    /*
    public async Task<HttpResponseMessage> UpdateProductAsync(int id, UpdateProductDto updatedProduct)
    {
        var request = new HttpRequestMessage(HttpMethod.Patch, $"api/product/{id}")
        {
            Content = JsonContent.Create(updatedProduct)
        };

        return await _http.SendAsync(request);
    }
    
    public async Task<HttpResponseMessage> DeleteProductAsync(int id)
    {
        return await _http.DeleteAsync($"api/product/{id}");
    }
    */
}