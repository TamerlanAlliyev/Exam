using ExamApp.Application.Services;
using ExamApp.Application.ViewModels.Lesson;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class LessonController : Controller
{
    private readonly ILessonService _service;

    public LessonController(ILessonService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(await _service.GetAllLessonAsync());
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
            return View(await _service.GetIncludeAsync(id));
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
            await _service.LessonDeleteAsync(id);
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
            return View(new LessonVM
            {
                SchoolClassSelect = await _service.GetSelectionClassAsync(),
            });
        }
        catch (Exception ex)
        {
            return View("Error404", ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(LessonVM vm)
    {
        try
        {
            await _service.CreateLessonAsync(vm);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return View("Error404", ex);
        }
    }
}
