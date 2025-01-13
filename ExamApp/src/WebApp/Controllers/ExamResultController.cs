using ExamApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ExamResultController:Controller
{
    private readonly IExamService _service;

    public ExamResultController(IExamService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    public async Task<IActionResult> Detail(int id)
    {
        return View(await _service.GetExamResltIncludeAsync(id));
    }
}
