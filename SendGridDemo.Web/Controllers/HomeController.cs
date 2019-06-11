using Microsoft.AspNetCore.Mvc;

namespace SendGridDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Documentation()
        {
            return View();
        }
    }
}
