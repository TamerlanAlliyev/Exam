using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Application.ViewModels.Student;
using ExamApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.Services;

public interface IStudentService
{
    Task CreateStudentAsync(StudentCreateVM vm);
    Task<List<Student>> GetAllStudent();
    Task<IEnumerable<SelectListItem>> GetSelectionClass();
    Task<StudentVM> GetStudentAsync(int id);
    Task DeleteStudentAsync(int id);
    Task<bool> GetAnyStudentAsync(int num);
}
