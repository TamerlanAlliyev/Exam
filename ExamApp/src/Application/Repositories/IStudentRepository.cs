using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.Repositories;

public interface IStudentRepository: IBaseRepository<Student>
{
    Task<IEnumerable<SelectListItem>> SelectionClass();
    Task<bool> AnyStudentAsync(int num);
}
