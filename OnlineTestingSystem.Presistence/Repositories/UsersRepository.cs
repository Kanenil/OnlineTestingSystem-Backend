using Microsoft.EntityFrameworkCore;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Presistence.Repositories
{
    public class UsersRepository : GenericRepository<UserEntity>, IUsersRepository
    {
        public UsersRepository(OnlineTestingDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IReadOnlyList<UserEntity>> GetAllAsync()
        {
            return await _dbContext.Users
                .Include(x => x.CourseUsers)
                    .ThenInclude(x=>x.Role)
                .Include(x => x.CourseUsers)
                    .ThenInclude(x => x.Course)
                .ToListAsync();
        }

        public override async Task<UserEntity> GetAsync(int id)
        {
            return await _dbContext.Users
                .Include(x => x.CourseUsers)
                    .ThenInclude(x => x.Role)
                .Include(x => x.CourseUsers)
                    .ThenInclude(x => x.Course)
                .FirstAsync(x => x.Id == id);
        }
    }
}
