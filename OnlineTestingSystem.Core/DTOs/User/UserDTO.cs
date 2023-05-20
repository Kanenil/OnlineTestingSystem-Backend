
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.DTOs.User
{
    public class UserDTO
    {
        public string Slug { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Image { get; set; }
        public string? BackgroundImage { get; set; }
        public ICollection<CourseRoleDTO> Courses { get; set; }
    }
}
