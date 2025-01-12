using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using ExamApp.Application.Repositories;
using ExamApp.Application.ViewModels.Teacher;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Infrastructure.Repositories;

public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
{
    private readonly ApplicationDbContext _context;

    public TeacherRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> GetAnyAsync(int number)
    {
      return await _context.Teachers.AnyAsync(t => t.Number == number);
    }
}
