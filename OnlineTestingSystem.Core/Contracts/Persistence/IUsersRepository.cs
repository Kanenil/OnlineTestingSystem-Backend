using OnlineTestingSystem.Domain;
using OnlineTestingSystem.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Contracts.Persistence
{
    public interface IUsersRepository : IGenericRepository<UserEntity>
    {
        public Task<UserEntity> GetUserBySlugAsync(string slug);
        public Task<UserEntity> GetUserByUsernameAsync(string username);
    }
}
