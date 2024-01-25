using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVC.Controllers
{
    public class HomeController2 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
