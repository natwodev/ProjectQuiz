using AutoMapper;
using backend_quiz.DTOs;
using backend_quiz.Entities;

namespace backend_quiz.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Exam, ExamDto>()
            .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));

        CreateMap<Question, QuestionDto>()
            .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers))
            .ForMember(dest => dest.ExamId, opt => opt.MapFrom(src => src.ExamId));

        CreateMap<Answer, AnswerDto>()
            .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.QuestionId));

        CreateMap<CreateExamDto, Exam>();
        CreateMap<UpdateExamDto, Exam>();
        CreateMap<CreateQuestionDto, Question>();
        CreateMap<UpdateQuestionDto, Question>();
        CreateMap<CreateAnswerDto, Answer>();
        CreateMap<UpdateAnswerDto, Answer>();
        CreateMap<Submission, SubmissionDto>();
        CreateMap<UserAnswer, UserAnswerDto>();
        CreateMap<CreateSubmissionDto, Submission>();
        CreateMap<CreateUserAnswerDto, UserAnswer>();
        CreateMap<UpdateSubmissionDto, Submission>();
        CreateMap<UpdateUserAnswerDto, UserAnswer>();
    }
}
