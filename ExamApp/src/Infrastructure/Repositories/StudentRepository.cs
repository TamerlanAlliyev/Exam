using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Application.Repositories;
using ExamApp.Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Infrastructure.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> AnyStudentAsync(int num)
    {
      return  await _context.Students.AnyAsync(x=>x.Number==num);
    }

    public async Task<IEnumerable<SelectListItem>> SelectionClass()
    {
        return await _context.SchoolClasses
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Class.ToString()
            })
            .ToListAsync();
    }
}
