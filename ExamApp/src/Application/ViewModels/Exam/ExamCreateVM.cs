using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.ViewModels.Exam;

public class ExamCreateVM
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int LessonId { get; set; }

    public IEnumerable<SelectListItem>? LessonSelect { get; set; }
}
