using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MVCBlogApp.UI.Controllers
{
    public class DoctorGeneralOptionsController : Controller
    {
        private readonly IMediator _mediator;

        public DoctorGeneralOptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Day

        [HttpGet]
        public async Task<IActionResult> DayList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DayCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DayCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DayUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DayUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> DayDelete(int a)
        {
            return View();
        }

        #endregion

        #region Meal

        [HttpGet]
        public async Task<IActionResult> MealList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MealCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MealCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MealUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MealUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> MealDelete(int a)
        {
            return View();
        }

        #endregion        
    }
}
