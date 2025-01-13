using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Application.ViewModels.Exam;
using ExamApp.Application.ViewModels.ExamResul;
using ExamApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.Services;

public interface IExamService
{
    Task<List<Exam>> GetAllExamAsync();

    Task CreateExamAsync(ExamCreateVM vm);
    Task<IEnumerable<SelectListItem>> GetSelectionLessonAsync();
    Task DeleteExamAsync(int id);
    Task<Exam> GetIncludeAsync(int id);
    Task<ExamResultVM> GetExamResltIncludeAsync(int id);
    Task CreateExamResult(ExamResultVM vm);
}
