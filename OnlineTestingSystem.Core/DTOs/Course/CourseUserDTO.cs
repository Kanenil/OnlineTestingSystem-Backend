using OnlineTestingSystem.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.DTOs.Course
{
    public class CourseUserDTO: BaseDTO<int>
    {
        public string? Image { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Section { get; set; }
        public string Slug { get; set; }
    }
}
