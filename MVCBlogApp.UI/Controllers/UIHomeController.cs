using Microsoft.AspNetCore.Mvc;

namespace MVCBlogApp.UI.Controllers
{
    public class UIHomeController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("LangID", 1);
            return View();
        }
    }
}
