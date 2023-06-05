using AutoMapper;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Application.DTOs.Course.Role;
using OnlineTestingSystem.Application.DTOs.User;
using OnlineTestingSystem.Domain;
using OnlineTestingSystem.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<CourseEntity, CourseDTO>()
                .ForMember(x => x.Users, opt => opt.MapFrom(x => x.CourseUsers))
                .ForMember(x => x.Tests, opt => opt.MapFrom(x => x.Tests));
            CreateMap<CourseEntity, CourseUserDTO>();

            CreateMap<UpdateCourseDTO, CourseEntity>();
            CreateMap<CourseCreateDTO, CourseEntity>();

            CreateMap<CourseUserEntity, CourseRoleDTO>()
                .ForMember(x => x.Role, opt => opt.MapFrom(x => x.Role))
                .ForMember(x => x.Course, opt => opt.MapFrom(x => x.Course));

            CreateMap<CourseRoleEntity, RoleDTO>();

        }
    }
}
