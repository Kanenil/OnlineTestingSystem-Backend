using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineTestingSystem.Application.Constants;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.Exeptions;
using OnlineTestingSystem.Application.Features.Courses.Requests.Commands;
using OnlineTestingSystem.Application.Responses;
using OnlineTestingSystem.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Courses.Handlers.Commands
{
    public class JoinCourseCommandHandler : IRequestHandler<JoinCourseCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<UserEntity> _userManager;

        public JoinCourseCommandHandler(IUnitOfWork unitOfWork, UserManager<UserEntity> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<BaseCommandResponse> Handle(JoinCourseCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var course = await _unitOfWork.CoursesRepository.GetAsync(request.CourseId);
            var user = await _userManager.FindByNameAsync(request.Username);

            if (course == null)
                throw new BadRequestException("Wrong course, course not found.");

            var role = await _unitOfWork.GetRoleAsync(CourseRoles.Student);

            await _unitOfWork.CourseUserRepository.AddAsync(new() { CourseId = course.Id, UserId = user.Id, RoleId = role.Id });
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Joined Successfully";

            return response;
        }
    }
}
