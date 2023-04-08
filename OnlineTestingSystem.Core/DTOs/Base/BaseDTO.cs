using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.DTOs.Base
{
    public abstract class BaseDTO<T>
    {
        public T Id { get; set; }
    }
}
