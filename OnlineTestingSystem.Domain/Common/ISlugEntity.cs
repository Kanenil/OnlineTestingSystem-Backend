using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Domain.Common
{
    public interface ISlugEntity
    {
        public string Slug { get; set; }
    }
}
