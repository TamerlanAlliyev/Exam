using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Application.ViewModels.Lesson;
using ExamApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.Services;

public interface ILessonService
{
    Task<List<Lesson>> GetAllLessonAsync();
    Task<Lesson> GetIncludeAsync(int id);
    Task<IEnumerable<SelectListItem>> GetSelectionClassAsync();
    Task CreateLessonAsync(LessonVM vm);
    Task LessonDeleteAsync(int id);
}
