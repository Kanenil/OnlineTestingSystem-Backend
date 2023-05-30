using OnlineTestingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICoursesRepository CoursesRepository { get; }
        ICourseUserRepository CourseUserRepository { get; }
        IUsersRepository UsersRepository { get; }
        ITestsRepository TestsRepository { get; }
        Task<CourseRoleEntity> GetRoleAsync(string name);
        Task Save();
    }
}
