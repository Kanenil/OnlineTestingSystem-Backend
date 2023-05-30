using OnlineTestingSystem.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.DTOs.Test;

public class TestCreateDTO 
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int CourseId { get; set; }
}
