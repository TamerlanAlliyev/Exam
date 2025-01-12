using ExamApp.Application.Common.Extensions;
using ExamApp.Application.Services;
using ExamApp.Application.ViewModels.Student;
using ExamApp.Application.ViewModels.Teacher;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers;

public class StudentController : Controller
{
    public readonly ApplicationDbContext _context;
    public readonly IStudentService _service;

    public StudentController(ApplicationDbContext context, IStudentService service)
    {
        _context = context;
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(await _service.GetAllStudent());
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
            return View(await _service.GetStudentAsync(id));
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
            await _service.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
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
            return View(new StudentCreateVM
            {
                Class = await _service.GetSelectionClass(),
            });
        }
        catch (Exception ex)
        {
            return View("Error404", ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(StudentCreateVM vm)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            else if (await _service.GetAnyStudentAsync(vm.Number))
            {
                ModelState.AddModelError("Number", "This number already exists.");
                return View(vm);
            }
            else if (!vm.Image.CheckFileSize(3))
            {
                ModelState.AddModelError("Image", "File size cannot exceed 3 mb");
                return View(vm);
            }
            else if (!vm.Image.CheckFileType("image"))
            {
                ModelState.AddModelError("Image", "File must be of image type");
                return View(vm);
            }

            await _service.CreateStudentAsync(vm);
            return RedirectToAction(nameof(Index));

        }
        catch (Exception ex)
        {
            return View("Error404", ex);
        }
    }


}
