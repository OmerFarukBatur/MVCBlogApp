using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealCreate;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetAllDays;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetByIdDay;
using MVCBlogApp.Application.Features.Queries.Doctor.Meal.GetAllMeals;

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
        public async Task<IActionResult> DayUpdate(GetByIdDayQueryRequest request)
        {
            GetByIdDayQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("DayList", "DoctorGeneralOptions");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DayUpdate(DayUpdateCommandRequest request)
        {
            DayUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("DayList", "DoctorGeneralOptions");
            }
            else
            {
                return RedirectToAction("DayUpdate", "DoctorGeneralOptions");
            }
        }

        public async Task<IActionResult> DayDelete(DayDeleteCommandRequest request)
        {
            DayDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("DayList", "DoctorGeneralOptions");
        }

        #endregion

        #region Meal

        [HttpGet]
        public async Task<IActionResult> MealList(GetAllMealsQueryRequest request)
        {
            GetAllMealsQueryResponse response = await _mediator.Send(request);
            return View(response.Meals);
        }

        [HttpGet]
        public IActionResult MealCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MealCreate(MealCreateCommandRequest request)
        {
            MealCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("MealList", "DoctorGeneralOptions");
            }
            else
            {
                return RedirectToAction("MealCreate", "DoctorGeneralOptions");
            }
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
