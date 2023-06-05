using OnlineTestingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Contracts.Persistence
{
    public interface ITestsRepository : IGenericRepository<TestEntity>
    {
        Task<QuestionEntity> AddQuestionAsync(QuestionEntity entity);
        Task<AnswerEntity> AddAnswerAsync(AnswerEntity entity);
    }
}
