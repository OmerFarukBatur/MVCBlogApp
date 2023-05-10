using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayCreate;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetAllDays;

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
        public async Task<IActionResult> DayList(GetAllDaysQueryRequest request)
        {
            GetAllDaysQueryResponse response = await _mediator.Send(request);
            return View(response.Days);
        }

        [HttpGet]
        public IActionResult DayCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DayCreate(DayCreateCommandRequest request)
        {
            DayCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("DayList", "DoctorGeneralOptions");
            }
            else
            {
                return RedirectToAction("DayCreate", "DoctorGeneralOptions");
            }
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
