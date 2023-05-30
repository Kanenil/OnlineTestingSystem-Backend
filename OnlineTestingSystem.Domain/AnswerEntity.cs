using OnlineTestingSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Domain;

[Table("tblAnswers")]
public class AnswerEntity : BaseEntity<int>
{
    [StringLength(4000)]
    public string Text { get; set; }

    public bool IsCorrect { get; set; }

    [ForeignKey("Question")]
    public int QuestionId { get; set; }
    public virtual QuestionEntity Question { get; set; }
}
