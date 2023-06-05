using OnlineTestingSystem.Application.DTOs.Base;
using OnlineTestingSystem.Application.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.DTOs.Answer;

public class AnswerDTO : BaseDTO<int>
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}
