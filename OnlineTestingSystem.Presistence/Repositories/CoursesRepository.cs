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
    public class CoursesRepository : GenericRepository<CourseEntity>, ICoursesRepository
    {
        public CoursesRepository(OnlineTestingDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<CourseEntity> GetAsync(int id)
        {
            return await _dbContext.Courses
                .Include(x => x.CourseUsers)
                    .ThenInclude(x => x.Role)
                .Include(x => x.CourseUsers)
                    .ThenInclude(x => x.User)
                .FirstAsync(x => x.Id == id);
        }

        public override async Task<IReadOnlyList<CourseEntity>> GetAllAsync()
        {
            return await _dbContext
                .Courses
                .Include(x=>x.CourseUsers)
                    .ThenInclude(x=>x.Role)
                .Include(x => x.CourseUsers)
                    .ThenInclude(x => x.User)
                .ToListAsync();
        }

        public async Task<string> GenerateCode()
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random rand = new Random();
            string code;

            do
            {
                code = new string(Enumerable.Repeat(letters, 7).Select(s => s[rand.Next(s.Length)]).ToArray());
            }
            while (await _dbContext.Courses.SingleOrDefaultAsync(x=>x.Code == code) != null);

            return code;
        }

        public async Task<CourseEntity> GetCourseBySlugAsync(string slug)
        {
            return await _dbContext.Courses
                .Include(x => x.CourseUsers)
                    .ThenInclude(x => x.Role)
                .Include(x => x.CourseUsers)
                    .ThenInclude(x => x.User)
                .FirstAsync(x => x.Slug == slug);
        }
    }
}
