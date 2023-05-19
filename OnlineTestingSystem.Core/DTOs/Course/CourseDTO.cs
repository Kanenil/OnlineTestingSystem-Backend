using OnlineTestingSystem.Application.DTOs.Base;
using OnlineTestingSystem.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.DTOs.Course
{
    public class CourseDTO : BaseDTO<int>, ICourseDTO
    {
        public string Code { get; set; }
        public string? Image { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Section { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsOnlyForCodeAccess { get; set; }
        public ICollection<UserRoleDTO> Users { get; set; }
    }
}
