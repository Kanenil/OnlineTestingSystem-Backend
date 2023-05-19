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
    public class GetCoursesListRequestHandler : IRequestHandler<GetCoursesListRequest, List<CourseDTO>>
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly IMapper _mapper;

        public GetCoursesListRequestHandler(ICoursesRepository coursesRepository, IMapper mapper)
        {
            _coursesRepository = coursesRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseDTO>> Handle(GetCoursesListRequest request, CancellationToken cancellationToken)
        {
            var courses = await _coursesRepository.GetAllAsync();
            return _mapper.Map<List<CourseDTO>>(courses);
        }
    }
}
