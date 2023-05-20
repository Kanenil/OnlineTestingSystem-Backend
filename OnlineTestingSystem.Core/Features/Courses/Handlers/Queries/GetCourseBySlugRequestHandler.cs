using AutoMapper;
using MediatR;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Application.Exeptions;
using OnlineTestingSystem.Application.Features.Courses.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Courses.Handlers.Queries
{
    public class GetCourseBySlugRequestHandler : IRequestHandler<GetCourseBySlugRequest, CourseDTO>
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly IMapper _mapper;

        public GetCourseBySlugRequestHandler(ICoursesRepository coursesRepository, IMapper mapper)
        {
            _coursesRepository = coursesRepository;
            _mapper = mapper;
        }
        public async Task<CourseDTO> Handle(GetCourseBySlugRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var course = await _coursesRepository.GetCourseBySlugAsync(request.Slug);
                return _mapper.Map<CourseDTO>(course);
            }
            catch 
            {
                throw new NotFoundException("Course with slug", request.Slug);
            }
        }
    }
}
