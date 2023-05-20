using OnlineTestingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Contracts.Persistence
{
    public interface ICoursesRepository : IGenericRepository<CourseEntity>
    {
        public Task<CourseEntity> GetCourseBySlugAsync(string slug);
        public Task<string> GenerateCode();
    }
}
