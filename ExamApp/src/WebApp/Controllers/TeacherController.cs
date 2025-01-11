using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using ExamApp.Application.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using ExamApp.Application.ViewModels.Teacher;
using AutoMapper;
using ExamApp.Application.Services;
namespace WebApp.Controllers;

public class TeacherController : Controller
{
    private readonly ApplicationDbContext _context;
    public readonly ITeacherService _teacherService;
    public TeacherController(ApplicationDbContext context,  ITeacherService teacherService)
    {
        _context = context;
        _teacherService= teacherService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _teacherService.GetAllTeacherAsync());
    }

    public async Task<IActionResult> Detail(int id)
    {
        return View(await _teacherService.GetTeacherAsync(id));
    }

    public async Task<IActionResult> Delete (int id)
    {
        await _teacherService.DeleteTeacherAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(TeacherCreateVM teacherVM)
    {
        if (!ModelState.IsValid)
        {
            return View(teacherVM);
        }
        else if (await _context.Teachers.AnyAsync(t => t.Number == teacherVM.Number))
        {
            ModelState.AddModelError("Number", "This number already exists.");
            return View(teacherVM);
        }
        else if (!teacherVM.Image.CheckFileSize(3))
        {
            ModelState.AddModelError("Image", "File size cannot exceed 3 mb");
            return View(teacherVM);
        }
        else if (!teacherVM.Image.CheckFileType("image"))
        {
            ModelState.AddModelError("Image", "File must be of image type");
            return View(teacherVM);
        }

        await _teacherService.CreateTeacherAsync(teacherVM);
        return RedirectToAction(nameof(Index));
    }
}
