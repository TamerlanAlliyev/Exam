using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using ExamApp.Application.ViewModels.Teacher;

namespace ExamApp.Application.Repositories;

public interface ITeacherRepository: IBaseRepository<Teacher>
{
    Task<bool> GetAnyAsync(int number);
}
