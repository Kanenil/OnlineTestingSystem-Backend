using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Constants
{
    public static class CourseRoles
    {
        public static List<string> All = new()
        {
            Owner,
            Moderator,
            Student
        };
        public const string Owner = "Owner";
        public const string Moderator = "Moderator";
        public const string Student = "Student";
    }
}
