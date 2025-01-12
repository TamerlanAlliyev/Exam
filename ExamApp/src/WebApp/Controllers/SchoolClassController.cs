using AutoMapper;
using Domain.Entities;
using ExamApp.Application.Repositories;
using ExamApp.Application.Services;
using ExamApp.Application.ViewModels.SchoolClass;
using ExamApp.Infrastructure.Services;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers;

public class SchoolClassController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ISchoolClassService _service;
    public SchoolClassController(ApplicationDbContext context, IMapper mapper, ISchoolClassService service)
    {
        _context = context;
        _mapper = mapper;
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(await _service.GetAllSchoolClassAsync());
        }
        catch (Exception ex)
        {
            return View("Error404", ex);
        }
    }

    public async Task<IActionResult> Create()
    {
        try
        {
            return View(new SchoolClassVM
            {
                Teachers = await _service.GetSelectionTeacher()
            });
        }
        catch (Exception ex)
        {
            return View("Error404", ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(SchoolClassVM vm)
    {
        try
        {
            await _service.CreateSchoolClassAsync(vm);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return View("Error404", ex);
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteSchoolClassAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return View("Error404", ex);
        }

    }

    public async Task<IActionResult> Detail(int id)
    {
        try
        {
            return View(await _context.SchoolClasses.Include(x => x.Teacher).FirstOrDefaultAsync(x => x.Id == id));
        }
        catch (Exception ex)
        {
            return View("Error404", ex);
        }
    }
}
