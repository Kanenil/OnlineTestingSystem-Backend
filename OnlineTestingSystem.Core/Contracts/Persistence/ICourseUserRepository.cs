using OnlineTestingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Contracts.Persistence
{
    public interface ICourseUserRepository : IGenericRepository<CourseUserEntity>
    {
        public Task<CourseUserEntity> GetCourseByUserIdAndCourseIdAsync(int userId, int courseId);
    }
}
