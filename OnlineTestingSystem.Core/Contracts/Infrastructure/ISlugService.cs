using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Contracts.Infrastructure
{
    public interface ISlugService
    {
        public string GenerateSlug(string textToSlug);
    }
}
