using OnlineTestingSystem.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Domain
{
    [Table("tblCourseUsers")]
    public class CourseUserEntity
    {
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual CourseEntity Course { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual CourseRoleEntity Role { get; set; }
    }
}
