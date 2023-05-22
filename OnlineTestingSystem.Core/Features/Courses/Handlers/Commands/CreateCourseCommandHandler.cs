using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineTestingSystem.Application.Constants;
using OnlineTestingSystem.Application.Contracts.Infrastructure;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Application.Features.Courses.Requests.Commands;
using OnlineTestingSystem.Application.Responses;
using OnlineTestingSystem.Domain;
using OnlineTestingSystem.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Courses.Handlers.Commands
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISlugService _slugService;
        private readonly UserManager<UserEntity> _userManager;

        public CreateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<UserEntity> userManager, ISlugService slugService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _slugService = slugService;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var course = _mapper.Map<CourseEntity>(request.CourseDTO);
            course.Code = await _unitOfWork.CoursesRepository.GenerateCode();

            var slug = _slugService.GenerateSlug(course.Name);

            try
            {
                var courseBySlug = await _unitOfWork.CoursesRepository.GetCourseBySlugAsync(slug);
                slug += $"-{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}";
            }
            catch
            {
                
            }

            course.Slug = slug;

            course = await _unitOfWork.CoursesRepository.AddAsync(course);
            await _unitOfWork.Save();

            var user = await _userManager.FindByNameAsync(request.Username);
            var role = await _unitOfWork.GetRoleAsync(CourseRoles.Owner);
            await _unitOfWork.CourseUserRepository.AddAsync(new() { CourseId = course.Id, UserId = user.Id, RoleId = role.Id });
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = course.Id;

            return response;
        }
    }
}
