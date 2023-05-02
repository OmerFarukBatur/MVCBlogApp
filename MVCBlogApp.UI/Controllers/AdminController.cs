using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;

namespace MVCBlogApp.UI.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly MVCBlogDbContext _context;

        public AdminController(MVCBlogDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //Genders genders = new() { 
            //    IsActive= true,
            //    LangID=0,
            //    Gender = "erkek"                
            //}; 
            
            //_context.Genders.Add(genders);
            //_context.SaveChanges();
            //var a = await _context.Genders.FirstOrDefaultAsync();
            
            return View();
        }
    }
}
