using frontend_quiz.DTOs;
using frontend_quiz.Services;
using Microsoft.AspNetCore.Components;


namespace frontend_quiz.Pages.Exam
{
    public partial class Show
    {
        [Parameter] public int id { get; set; }

        [Inject] private ExamService ExamService { get; set; } = default!;
        [Inject] private AuthService AuthService { get; set; } = default!;
        [Inject] private NavigationManager NavigationManager { get; set; } = default!;
        [Inject] private QuestionService questionService { get; set; } = default!;

        private ExamDto? _exam;
        private bool _isAdmin;
        private bool _isAuthenticated;
        private bool _showConfirmDialog = false;
        private int _questionIdToDelete;

        private CreateQuestionDto _question = new()
        {
            Content = "",
            Answers = new List<CreateAnswerDto> { new CreateAnswerDto() }
        };

        private string? _message;

        private void AskDelete(int questionId)
        {
            _questionIdToDelete = questionId;
            _showConfirmDialog = true;
        }

        private async Task ConfirmDelete()
        {
            await DeleteQuestion(_questionIdToDelete);
            _showConfirmDialog = false;
        }

        private void CancelDelete()
        {
            _showConfirmDialog = false;
        }

        private async Task HandleValidSubmit()
        {
            if (string.IsNullOrWhiteSpace(_question.Content))
            {
                _message = "Vui lòng nhập nội dung câu hỏi!";
                return;
            }

            if (_question.Answers.Count < 2)
            {
                _message = "Phải có ít nhất 2 câu trả lời.";
                return;
            }

            if (!_question.Answers.Any(a => a.IsCorrect))
            {
                _message = "Phải chọn ít nhất 1 câu trả lời đúng.";
                return;
            }

            if (_question.Answers.Any(a => string.IsNullOrWhiteSpace(a.Content)))
            {
                _message = "Vui lòng nhập nội dung cho tất cả các câu trả lời!";
                return;
            }

            var response = await questionService.CreateQuestionAsync(id, _question);
            if (response.IsSuccessStatusCode)
            {
                _message = "Tạo câu hỏi thành công!";
                _question = new CreateQuestionDto
                {
                    Content = "",
                    Answers = new List<CreateAnswerDto> { new CreateAnswerDto() }
                };
                _exam = await ExamService.GetExamByIdAsync(id); 
            }
            else
            {
                _message = "Đã xảy ra lỗi khi tạo câu hỏi.";
            }
        }

        private void AddAnswer()
        {
            _question.Answers.Add(new CreateAnswerDto());
        }

        private void RemoveAnswer(int index)
        {
            if (_question.Answers.Count > 1)
            {
                _question.Answers.RemoveAt(index);
            }
        }

        private void GoBackToExams()
        {
            NavigationManager.NavigateTo("/exams");
        }

        private void MarkAsCorrect(int selectedIndex)
        {
            for (int i = 0; i < _question.Answers.Count; i++)
            {
                _question.Answers[i].IsCorrect = (i == selectedIndex);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            _isAuthenticated = await AuthService.IsAuthenticated();
            _isAdmin = await AuthService.IsAdmin();

            if (!_isAuthenticated)
            {
                return;
            }

            if (!_isAdmin)
            {
                NavigationManager.NavigateTo("/");
                return;
            }

            _exam = await ExamService.GetExamByIdAsync(id);
        }

        private async Task DeleteQuestion(int questionId)
        {
            var result = await questionService.DeleteQuestionAsync(questionId);
            if (result)
            {
                _message = "Đã xoá câu hỏi thành công!";
                _exam = await ExamService.GetExamByIdAsync(id);
            }
            else
            {
                _message = "Không thể xoá câu hỏi. Có thể câu hỏi không tồn tại.";
            }
        }
    }
}
