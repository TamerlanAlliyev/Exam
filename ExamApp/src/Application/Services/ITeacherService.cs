using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Application.ViewModels.Teacher;

namespace ExamApp.Application.Services;

public interface ITeacherService
{
    Task<TeacherCreateVM> CreateTeacherAsync(TeacherCreateVM vm);
    Task DeleteTeacherAsync(int id);
    Task<IEnumerable<TeacherVM>> GetAllTeacherAsync();
    Task<TeacherVM> GetTeacherAsync(int id);
    Task<bool> GetAnyTeacherAsync(int number);
}
