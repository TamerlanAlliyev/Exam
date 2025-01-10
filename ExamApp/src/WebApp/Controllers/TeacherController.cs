using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
