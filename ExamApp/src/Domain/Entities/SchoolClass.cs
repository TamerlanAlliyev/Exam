using Domain.Common;
using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class SchoolClass : BaseEntity
{
    public int Class { get; set; } 
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public List<Student>? Students { get; set; }
    public List<Lesson>? Lessons { get; set; }

}

