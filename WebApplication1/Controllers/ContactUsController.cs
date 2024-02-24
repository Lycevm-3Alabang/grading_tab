using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Hello() => "Hello World!";
        public string HelloFromMain() => "Hello world from (main) branch";
    }
}
