using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace ExamApp.Domain.Entities;

public class Exam:BaseEntity
{
    public DateTime Date { get; set; }
    public bool Status { get; set; }
    public decimal?  ClassAverage { get; set; }
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;
    public ExamResult? ExamResult { get; set; }
}
