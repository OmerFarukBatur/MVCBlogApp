﻿using Microsoft.AspNetCore.Mvc;

namespace MVCBlogApp.UI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }
    }
}
