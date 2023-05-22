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
    public class LeaveCourseCommandHandler : IRequestHandler<LeaveCourseCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<UserEntity> _userManager;

        public LeaveCourseCommandHandler(IUnitOfWork unitOfWork, UserManager<UserEntity> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<BaseCommandResponse> Handle(LeaveCourseCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var course = await _unitOfWork.CoursesRepository.GetAsync(request.CourseId);
            var user = await _userManager.FindByNameAsync(request.Username);

            if (course == null)
                throw new NotFoundException("Course", "course");

            var ownerRole = await _unitOfWork.GetRoleAsync(CourseRoles.Owner);

            var courseUser = await _unitOfWork.CourseUserRepository.GetCourseByUserIdAndCourseIdAsync(user.Id, course.Id);

            if(courseUser == null)
                throw new NotFoundException("Course User", "courseUser");

            if (courseUser.RoleId == ownerRole.Id)
                throw new BadRequestException("You can not to leave from own course");

            await _unitOfWork.CourseUserRepository.DeleteAsync(courseUser);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Leaved Successfully";

            return response;
        }
    }
}
