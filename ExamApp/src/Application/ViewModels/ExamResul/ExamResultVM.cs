using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Domain.Entities;

namespace ExamApp.Application.ViewModels.ExamResul;

public class ExamResultVM
{
    public int ExamId { get; set; }
    public string LessonName { get; set; } = null!;
    public string LessonCode { get; set; } = null!;
    public int ClassNumber { get; set; }
    public string TeacherFullName { get; set; } = null!;
    public int? StudentCount { get; set; }
    public DateTime Date { get; set; }
    public List<ExamResultCreateVM>? ExamResultStudents { get; set; }
}
