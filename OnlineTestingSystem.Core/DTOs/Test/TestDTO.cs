using OnlineTestingSystem.Application.DTOs.Base;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Application.DTOs.Question;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.DTOs.Test;

public class TestDTO: BaseDTO<int>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<QuestionDTO> Questions { get; set; }
}
