using OnlineTestingSystem.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.DTOs.Course
{
    public class UpdateCourseDTO : BaseDTO<int>, ICourseDTO
    {
        public string? Image { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Section { get; set; }
    }
}
