using Microsoft.AspNetCore.Http;
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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineTestingDbContext _context;
        private ICoursesRepository _coursesRepository;
        private ICourseUserRepository _courseUserRepository;
        private IUsersRepository _usersRepository;

        public UnitOfWork(OnlineTestingDbContext context)
        {
            _context = context;
        }

        public ICoursesRepository CoursesRepository =>
            _coursesRepository ??= new CoursesRepository(_context); 

        public ICourseUserRepository CourseUserRepository =>
            _courseUserRepository ??= new CourseUserRepository(_context);

        public IUsersRepository UsersRepository =>
            _usersRepository ??= new UsersRepository(_context);

        public async Task<CourseRoleEntity> GetRoleAsync(string name)
        {
            return await _context.CourseRoles.FirstOrDefaultAsync(x => x.Name == name);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
