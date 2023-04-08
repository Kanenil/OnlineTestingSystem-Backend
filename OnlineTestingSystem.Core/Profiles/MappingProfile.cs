using AutoMapper;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Course Mappings
            CreateMap<CourseEntity, CourseDTO>().ReverseMap();
            CreateMap<CourseEntity, UpdateCourseDTO>().ReverseMap();
            CreateMap<CourseEntity, CreateCourseDTO>().ReverseMap();
            #endregion
        }
    }
}
