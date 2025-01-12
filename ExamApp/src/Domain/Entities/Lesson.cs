using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace ExamApp.Domain.Entities;

public class Lesson:BaseEntity
{
    public string LessonCode { get; set; } = null!;
    public string LessonName { get; set;} = null!;
    public int SchoolClassId { get; set; }
    public SchoolClass SchoolClass { get; set; } = null!;
    public int? ExamId { get; set; }
    public Exam? Exam { get; set; }

}
