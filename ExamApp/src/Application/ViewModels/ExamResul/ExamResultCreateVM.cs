using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.ViewModels.ExamResul;

public class ExamResultCreateVM
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int StudentNumber { get; set; }
    public string StudentFullName { get; set; } = null!;
    public decimal LessonAverage { get; set; }
    public decimal ExamRes { get; set; }
}
