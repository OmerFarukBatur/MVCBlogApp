using Microsoft.AspNetCore.Mvc;

namespace MVCBlogApp.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
