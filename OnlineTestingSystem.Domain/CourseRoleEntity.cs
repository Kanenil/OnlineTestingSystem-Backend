using OnlineTestingSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Domain
{
    [Table("tblCourseRoles")]
    public class CourseRoleEntity : BaseEntity<int>
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
    }
}
