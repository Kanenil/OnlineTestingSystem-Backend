using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Exeptions
{
    public class UnAuthorizedExeption : ApplicationException
    {
        public UnAuthorizedExeption(string message):base(message)
        {
            
        }
    }
}
