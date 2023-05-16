using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Lab.LabCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Lab.LabDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Lab.LabUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealUpdate;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetAllDays;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetByIdDay;
using MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetAllDietList;
using MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetByIdDietList;
using MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetDietListCreateItems;
using MVCBlogApp.Application.Features.Queries.Doctor.Examination.GetAllExamination;
using MVCBlogApp.Application.Features.Queries.Doctor.Examination.GetByIdExamination;
using MVCBlogApp.Application.Features.Queries.Doctor.Lab.GetAllLab;
using MVCBlogApp.Application.Features.Queries.Doctor.Lab.GetByIdLab;
using MVCBlogApp.Application.Features.Queries.Doctor.Lab.GetLabCreateItems;
using MVCBlogApp.Application.Features.Queries.Doctor.Meal.GetAllMeals;
using MVCBlogApp.Application.Features.Queries.Doctor.Meal.GetByIdMeal;

namespace MVCBlogApp.UI.Controllers
{
    public class DoctorGeneralOptionsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public DoctorGeneralOptionsController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
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
        public async Task<IActionResult> MealUpdate(GetByIdMealQueryRequest request)
        {
            GetByIdMealQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("MealUpdate", "DoctorGeneralOptions");
            }
        }

        [HttpPost]
        public async Task<IActionResult> MealUpdate(MealUpdateCommandRequest request)
        {
            MealUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("MealList", "DoctorGeneralOptions");
            }
            else
            {
                return RedirectToAction("MealUpdate", "DoctorGeneralOptions");
            }
        }

        public async Task<IActionResult> MealDelete(MealDeleteCommandRequest request)
        {
            MealDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("MealList", "DoctorGeneralOptions");
        }

        #endregion        

        #region DietList

        [HttpGet]
        public async Task<IActionResult> DietList(GetAllDietListQueryRequest request)
        {
            GetAllDietListQueryResponse response = await _mediator.Send(request);
            return View(response.AllDietLists);
        }

        [HttpGet]
        public async Task<IActionResult> DietListCreate(GetDietListCreateItemsQueryRequest request)
        {
            GetDietListCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> DietListCreate(DietListCreateCommandRequest request)
        {
            request.UserId = _operationService.GetUser().Id;
            DietListCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("DietList", "DoctorGeneralOptions");
            }
            else
            {
                return RedirectToAction("DietListCreate", "DoctorGeneralOptions");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DietListUpdate(GetByIdDietListQueryRequest request)
        {
            GetByIdDietListQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("DietListUpdate", "DoctorGeneralOptions");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DietListUpdate(DietListUpdateCommandRequest request)
        {
            DietListUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("DietList", "DoctorGeneralOptions");
            }
            else
            {
                return RedirectToAction("DietListUpdate", "DoctorGeneralOptions");
            }
        }

        public async Task<IActionResult> DietListDelete(DietListDeleteCommandRequest request)
        {
            DietListDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("DietList", "DoctorGeneralOptions");
        }

        #endregion        

        #region Examination

        [HttpGet]
        public async Task<IActionResult> ExaminationList(GetAllExaminationQueryRequest request)
        {
            GetAllExaminationQueryResponse response = await _mediator.Send(request);
            return View(response.Examinations);
        }

        [HttpGet]
        public IActionResult ExaminationCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ExaminationCreate(ExaminationCreateCommandRequest request)
        {
            ExaminationCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ExaminationList", "DoctorGeneralOptions");
            }
            else
            {
                return RedirectToAction("ExaminationCreate", "DoctorGeneralOptions");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ExaminationUpdate(GetByIdExaminationQueryRequest request)
        {
            GetByIdExaminationQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("ExaminationUpdate", "DoctorGeneralOptions");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExaminationUpdate(ExaminationUpdateCommandRequest request)
        {
            ExaminationUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ExaminationList", "DoctorGeneralOptions");
            }
            else
            {
                return RedirectToAction("ExaminationUpdate", "DoctorGeneralOptions");
            }
        }

        public async Task<IActionResult> ExaminationDelete(ExaminationDeleteCommandRequest request)
        {
            ExaminationDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ExaminationList", "DoctorGeneralOptions");
        }

        #endregion

        #region Lab

        [HttpGet]
        public async Task<IActionResult> LabList(GetAllLabQueryRequest request)
        {
            GetAllLabQueryResponse response = await _mediator.Send(request);
            return View(response.Labs);
        }

        [HttpGet]
        public async Task<IActionResult> LabCreate(GetLabCreateItemsQueryRequest request)
        {
            GetLabCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> LabCreate(LabCreateCommandRequest request)
        {
            LabCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("LabList", "DoctorGeneralOptions");
            }
            else
            {
                return RedirectToAction("LabCreate", "DoctorGeneralOptions");
            }
        }

        [HttpGet]
        public async Task<IActionResult> LabUpdate(GetByIdLabQueryRequest request)
        {
            GetByIdLabQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("LabUpdate", "DoctorGeneralOptions");
            }
        }

        [HttpPost]
        public async Task<IActionResult> LabUpdate(LabUpdateCommandRequest request)
        {
            LabUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("LabList", "DoctorGeneralOptions");
            }
            else
            {
                return RedirectToAction("LabUpdate", "DoctorGeneralOptions");
            }
        }

        public async Task<IActionResult> LabDelete(LabDeleteCommandRequest request)
        {
            LabDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("LabList", "DoctorGeneralOptions");
        }

        #endregion        
    }
}
