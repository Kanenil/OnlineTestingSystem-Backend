using OnlineTestingSystem.Application.DTOs.Answer;
using OnlineTestingSystem.Application.DTOs.Base;
using OnlineTestingSystem.Application.DTOs.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.DTOs.Question;

public class QuestionDTO : BaseDTO<int>
{
    public string Text { get; set; }
    public ICollection<AnswerDTO> Answers { get; set; }
}
