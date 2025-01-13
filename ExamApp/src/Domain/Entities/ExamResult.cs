using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace ExamApp.Domain.Entities;

public class ExamResult : BaseEntity
{
    public decimal LessonAverage { get; set; }
    public decimal ExamRes { get; set; }
    public decimal Average { get; set; }

    public int ExamId { get; set; }
    public Exam Exam { get; set; } = null!;

    public int StudentId { get; set; }

    public Student Student { get; set; } = null!;
}
