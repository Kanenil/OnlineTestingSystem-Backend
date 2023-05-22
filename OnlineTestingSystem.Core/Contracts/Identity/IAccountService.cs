using OnlineTestingSystem.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Contracts.Identity
{
    public interface IAccountService
    {
        Task<UserDTO> Profile(string username);
        Task Logout(string username);
    }
}
