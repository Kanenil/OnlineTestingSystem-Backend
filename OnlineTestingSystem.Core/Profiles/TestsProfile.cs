using AutoMapper;
using OnlineTestingSystem.Application.DTOs.Answer;
using OnlineTestingSystem.Application.DTOs.Question;
using OnlineTestingSystem.Application.DTOs.Test;
using OnlineTestingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Profiles
{
    public class TestsProfile : Profile
    {
        public TestsProfile()
        {
            CreateMap<TestCreateDTO, TestEntity>();
            CreateMap<TestUpdateDTO, TestEntity>();
            CreateMap<TestEntity, TestDTO>()
                .ForMember(x => x.Questions, opt => opt.MapFrom(x => x.Questions));

            CreateMap<AnswerCreateDTO, AnswerEntity>();
            CreateMap<AnswerEntity, AnswerDTO>();

            CreateMap<QuestionCreateDTO, QuestionEntity>();
            CreateMap<QuestionEntity, QuestionDTO>()
                .ForMember(x => x.Answers, opt => opt.MapFrom(x => x.Answers));
        }
    }
}
