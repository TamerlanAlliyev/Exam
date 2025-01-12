using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.ViewModels.Exam;

public class ExamVM
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
    public decimal? ClassAverage { get; set; }
    // Lesson class was not visible
    public Domain.Entities.Lesson Lesson { get; set; } = null!;
    public IEnumerable<SelectListItem>? LessonSelect { get; set; }

}
