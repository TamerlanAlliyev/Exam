using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Application.Repositories;
using ExamApp.Application.ViewModels.Lesson;
using ExamApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.Repositoriesp;

public interface ILessonRepository : IBaseRepository<Lesson>
{
    Task<IEnumerable<SelectListItem>> SelectionClassAsync();
    Task<List<Lesson>> GetAllIncludeAsync();
    Task<Lesson> GetIncludeAsync(int id);
}
