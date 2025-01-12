using ExamApp.Application.Services;
using ExamApp.Application.ViewModels.Exam;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ExamController : Controller
{
    private readonly IExamService _service;

    public ExamController(IExamService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        try
        {

        }
        catch (Exception ex)
        {
            return View("Error404");
        }
        return View(await _service.GetAllExamAsync());
    }

    public async Task<IActionResult> Create()
    {
        try
        {
            return View(new ExamCreateVM
            {
                LessonSelect = await _service.GetSelectionLessonAsync()
            });
        }
        catch (Exception ex)
        {
            return View("Error404");
        }

    }

    [HttpPost]
    public async Task<IActionResult> Create(ExamCreateVM vm)
    {
        try
        {
            await _service.CreateExamAsync(vm);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return View("Error404");
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteExamAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return View("Error404");
        }
    }
}
