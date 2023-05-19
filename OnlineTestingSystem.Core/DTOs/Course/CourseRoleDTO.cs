using OnlineTestingSystem.Application.DTOs.Course.Role;
using OnlineTestingSystem.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.DTOs.Course
{
    public class CourseRoleDTO
    {
        public RoleDTO Role { get; set; }
        public CourseUserDTO Course { get; set; }
    }
}
