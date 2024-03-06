using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class SectionsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}