using AutoMapper;
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
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserEntity, UserDTO>()
                .ForMember(x => x.Courses, opt => opt.MapFrom(x => x.CourseUsers));

            CreateMap<UserEntity, UserCourseDTO>();

            CreateMap<CourseUserEntity, UserRoleDTO>()
                .ForMember(x => x.Role, opt => opt.MapFrom(x => x.Role))
                .ForMember(x => x.User, opt => opt.MapFrom(x => x.User));
        }
    }
}
