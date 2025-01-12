using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.Repositories;

public interface ISchoolClassRepository : IBaseRepository<SchoolClass>
{
    Task<IEnumerable<SelectListItem>> SelectionTeacher();
}
