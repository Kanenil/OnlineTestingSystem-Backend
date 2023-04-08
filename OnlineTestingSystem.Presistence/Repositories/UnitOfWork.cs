using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineTestingSystem.Application.Contracts.Persistence;
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

        public UnitOfWork(OnlineTestingDbContext context)
        {
            _context = context;
        }

        public ICoursesRepository CoursesRepository =>
            _coursesRepository ??= new CoursesRepository(_context);

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
