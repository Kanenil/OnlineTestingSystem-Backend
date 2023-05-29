using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Models.Course
{
    public class CourseSearch
    {
        public int Page { get; set; }
        public string Search { get; set; } = string.Empty;
        public int CountOnPage { get; set; } = 10;
    }
}
