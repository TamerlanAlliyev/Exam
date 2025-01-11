using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class SchoolClassController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
