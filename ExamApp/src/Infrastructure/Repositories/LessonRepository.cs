using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExamApp.Application.Repositories;
using ExamApp.Application.Repositoriesp;
using ExamApp.Application.ViewModels.Lesson;
using ExamApp.Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Infrastructure.Repositories;

public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
{
    private readonly ApplicationDbContext _context;
    public LessonRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Lesson>> GetAllIncludeAsync()
    {
        return await _context.Lessons.Include(x => x.SchoolClass)
                                     .Include(x => x.SchoolClass.Students)
                                     .Include(x => x.SchoolClass.Teacher)
                                     .ToListAsync();
    }

    public async Task<Lesson> GetIncludeAsync(int id)
    {
        var lesson = await _context.Lessons
                                   .Include(x => x.SchoolClass)
                                   .Include(x => x.SchoolClass.Students)
                                   .Include(x => x.SchoolClass.Teacher)
                                   .Include(x=>x.Exam)
                                   .FirstOrDefaultAsync(x => x.Id == id);

        if (lesson == null)
        {
            throw new KeyNotFoundException("Lesson not found");
        }

        return lesson;
    }

 
    public async Task<IEnumerable<SelectListItem>> SelectionClassAsync()
    {
        return await _context.SchoolClasses.Select(t => new SelectListItem
        {
            Value = t.Id.ToString(),
            Text = t.Class.ToString()
        }).ToListAsync();
    }
}
