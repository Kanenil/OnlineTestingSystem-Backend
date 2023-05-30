using OnlineTestingSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Domain;

[Table("tblTests")]
public class TestEntity : BaseEntity<int>
{
    [StringLength(255)]
    public string Name { get; set; }

    [StringLength(4000)]
    public string? Description { get; set; }

    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public virtual CourseEntity Course { get; set; }

    public virtual ICollection<QuestionEntity> Questions { get; set; }
}
