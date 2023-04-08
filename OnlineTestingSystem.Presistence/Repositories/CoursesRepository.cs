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
        private readonly OnlineTestingDbContext _dbContext;
        public CoursesRepository(OnlineTestingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
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
    }
}
