using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTestingSystem.Application.DTOs.Course.Role;

namespace OnlineTestingSystem.Application.DTOs.User
{
    public class UserRoleDTO
    {
        public RoleDTO Role { get; set; }
        public UserCourseDTO User { get; set; }
    }
}
