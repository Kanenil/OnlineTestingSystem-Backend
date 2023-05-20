using OnlineTestingSystem.Application.Contracts.Infrastructure;
using Slugify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Infrastructure.Slug
{
    public class SlugService : ISlugService
    {
        private readonly ISlugHelper _slugHelper;

        public SlugService(ISlugHelper slugHelper)
        {
            _slugHelper = slugHelper;
        }

        public string GenerateSlug(string textToSlug)
        {
            return _slugHelper.GenerateSlug(textToSlug);
        }
    }
}
