using Microsoft.EntityFrameworkCore;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Presistence.Repositories
{
    public class CourseUserRepository : GenericRepository<CourseUserEntity>, ICourseUserRepository
    {
        public CourseUserRepository(OnlineTestingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CourseUserEntity> GetCourseByUserIdAndCourseIdAsync(int userId, int courseId)
        {
            return await _dbContext.CourseUsers.FirstOrDefaultAsync(x=>x.UserId == userId && x.CourseId == courseId);
        }
    }
}
