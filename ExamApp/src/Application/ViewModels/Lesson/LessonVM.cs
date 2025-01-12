using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Application.ViewModels.SchoolClass;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.ViewModels.Lesson;

public class LessonVM
{
    public string LessonCode { get; set; } = null!;
    public string LessonName { get; set; } = null!;
    public int SchoolClassId { get; set; }
    public IEnumerable<SelectListItem>? SchoolClassSelect { get; set; }
    public SchoolClassVM? SchoolClass { get; set; }
    public int StudentCount { get; set; }

}
