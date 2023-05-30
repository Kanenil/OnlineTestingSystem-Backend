using OnlineTestingSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Domain;

[Table("tblQuestions")]
public class QuestionEntity : BaseEntity<int>
{
    [StringLength(4000)]
    public string Text { get; set; }

    [ForeignKey("Test")]
    public int TestId { get; set; }
    public virtual TestEntity Test { get; set; }

    public virtual ICollection<AnswerEntity> Answers { get; set; }
}
