using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Presistence.Repositories
{
    public class TestsRepository : GenericRepository<TestEntity>, ITestsRepository
    {
        public TestsRepository(OnlineTestingDbContext dbContext) : base(dbContext) {}

        public override async Task DeleteAsync(TestEntity entity)
        {
            var data = await GetAsync(entity.Id);
            data.IsDeleted = true;
        }
    }
}
