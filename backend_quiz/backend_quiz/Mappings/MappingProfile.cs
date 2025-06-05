using AutoMapper;
using backend_quiz.DTOs;
using backend_quiz.Entities;

namespace backend_quiz.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Exam mappings
        CreateMap<Exam, ExamDto>();
        CreateMap<CreateExamDto, Exam>();
        CreateMap<UpdateExamDto, Exam>();

        // Question mappings
        CreateMap<Question, QuestionDto>();
        CreateMap<CreateQuestionDto, Question>();
        CreateMap<UpdateQuestionDto, Question>();

        // Answer mappings
        CreateMap<Answer, AnswerDto>();
        CreateMap<CreateAnswerDto, Answer>();
        CreateMap<UpdateAnswerDto, Answer>();

        // Submission mappings
        CreateMap<Submission, SubmissionDto>();
        CreateMap<CreateSubmissionDto, Submission>();
        CreateMap<UpdateSubmissionDto, Submission>();

        // UserAnswer mappings
        CreateMap<UserAnswer, UserAnswerDto>();
        CreateMap<CreateUserAnswerDto, UserAnswer>();
        CreateMap<UpdateUserAnswerDto, UserAnswer>();

        // ApplicationUser mappings removed as per request
    }
}
