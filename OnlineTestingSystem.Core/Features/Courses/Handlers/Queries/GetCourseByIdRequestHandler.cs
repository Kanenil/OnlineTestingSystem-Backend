using AutoMapper;
using MediatR;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Application.Features.Courses.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Courses.Handlers.Queries
{
    public class GetCourseByIdRequestHandler : IRequestHandler<GetCourseByIdRequest, CourseDTO>
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly IMapper _mapper;

        public GetCourseByIdRequestHandler(ICoursesRepository coursesRepository, IMapper mapper)
        {
            _coursesRepository = coursesRepository;
            _mapper = mapper;
        }
        public async Task<CourseDTO> Handle(GetCourseByIdRequest request, CancellationToken cancellationToken)
        {
            var course = await _coursesRepository.GetAsync(request.Id);
            return _mapper.Map<CourseDTO>(course);
        }
    }
}
