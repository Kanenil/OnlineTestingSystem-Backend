using OnlineTestingSystem.Domain.Common;
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
    [Table("tblCourses")]
    public class CourseEntity : BaseEntity<int>
    {
        [Required, StringLength(12)]
        public string Code { get; set; }
        [StringLength(100)]
        public string? Image { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(4000)]
        public string? Description { get; set; }
        [StringLength(255)]
        public string? Section { get; set; }
        [Required]
        public bool IsOnlyForCodeAccess { get; set; } = false;
        public virtual ICollection<CourseUserEntity> CourseUsers { get; set; }
    }
}
