﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICoursesRepository CoursesRepository { get; }
        Task Save();
    }
}
