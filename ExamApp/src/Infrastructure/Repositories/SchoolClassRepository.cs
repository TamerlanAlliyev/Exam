using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using ExamApp.Application.Repositories;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Infrastructure.Repositories;

public class SchoolClassRepository : BaseRepository<SchoolClass>, ISchoolClassRepository
{
    private readonly ApplicationDbContext _context;

    public SchoolClassRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SelectListItem>> SelectionTeacher()
    {
        return await _context.Teachers
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            })
            .ToListAsync();
    }
}
