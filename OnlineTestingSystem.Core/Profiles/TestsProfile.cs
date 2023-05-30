using AutoMapper;
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
        }
    }
}
