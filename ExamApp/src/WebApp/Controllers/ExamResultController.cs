using ExamApp.Application.Services;
using ExamApp.Application.ViewModels.Exam;
using ExamApp.Application.ViewModels.ExamResul;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ExamResultController:Controller
{
    private readonly IExamService _service;
    public ExamResultController(IExamService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task<IActionResult> Create(ExamResultVM vm)
    {
        try
        {
            await _service.CreateExamResult(vm);
            return RedirectToAction("Index", "Exam");
        }
        catch (Exception ex)
        {
            return View("Error404");
        }
    }

    public async Task<IActionResult> Detail(int id)
    {
        try
        {
            return View(await _service.GetExamResltIncludeAsync(id));
        }
        catch (Exception ex)
        {
            return View("Error404");
        }
    }
}
