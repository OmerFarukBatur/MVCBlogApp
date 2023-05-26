using Microsoft.AspNetCore.Mvc;

namespace MVCBlogApp.UI.Controllers
{
    public class DoctorCalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
