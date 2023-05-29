using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Application.Features.Courses.Requests.Queries;
using OnlineTestingSystem.Application.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineTestingSystem.Application.Features.Courses.Handlers.Queries
{
    public class GetPaginatedCoursesListRequestHandler : IRequestHandler<GetPaginatedCoursesListRequest, CourseSearchResult>
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly IMapper _mapper;

        public GetPaginatedCoursesListRequestHandler(ICoursesRepository coursesRepository, IMapper mapper)
        {
            _coursesRepository = coursesRepository;
            _mapper = mapper;
        }

        public async Task<CourseSearchResult> Handle(GetPaginatedCoursesListRequest request, CancellationToken cancellationToken)
        {
            var query = _coursesRepository.GetAllAsQueryable()
                .Where(x => x.IsOnlyForCodeAccess == false && x.IsDeleted == false);


            if (!string.IsNullOrEmpty(request.Search.Search))
            {
                query = query.Where(x => x.Name.ToLower().Contains(request.Search.Search.ToLower()));
            }


            var courses = await query.Skip((request.Search.Page -1) * request.Search.CountOnPage)
                .Take(request.Search.CountOnPage)
                .Select(x => _mapper.Map<CourseDTO>(x))
                .ToListAsync();

            int total = query.Count();
            int pages = (int)Math.Ceiling(total / (double)request.Search.CountOnPage);

            return new()
            {
                CurrentPage = request.Search.Page,
                Pages = pages,
                Total = total,
                Courses = courses,
            };
        }
    }
}
