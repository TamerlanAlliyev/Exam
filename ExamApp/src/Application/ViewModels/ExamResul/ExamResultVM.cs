using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.ViewModels.ExamResul;

public class ExamResultVM
{
    public Domain.Entities.Exam Exam { get; set; } = null!;

    public List<ExamResultCreateVM>? ExamResultStudents { get; set; }
}
