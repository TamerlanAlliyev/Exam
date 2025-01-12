using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using ExamApp.Application.ViewModels.SchoolClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.Services;

public interface ISchoolClassService
{
    Task CreateSchoolClassAsync(SchoolClassVM vm);
    Task<List<SchoolClass>> GetAllSchoolClassAsync();
    Task<SchoolClassVM> GetSchoolClassAsync(int id);
    Task DeleteSchoolClassAsync(int id);
    Task<IEnumerable<SelectListItem>> GetSelectionTeacher();
}
