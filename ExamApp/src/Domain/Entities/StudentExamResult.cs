using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace ExamApp.Domain.Entities;

public class StudentExamResult:BaseEntity
{
    public int ExamResultId { get; set; }
    public ExamResult ExamResult { get; set; } = null!;
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
}
