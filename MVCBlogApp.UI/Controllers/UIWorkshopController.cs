using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.UIWorkShop.CreateWorkShopApplicationForm;
using MVCBlogApp.Application.Features.Queries.IUWorkShop.GetWhereWorkShop;
using MVCBlogApp.Application.Features.Queries.IUWorkShop.GetWorkshop;
using MVCBlogApp.Application.Features.Queries.IUWorkShop.GetWorkshopEducation;
using MVCBlogApp.Application.Features.Queries.IUWorkShop.WorkShopApplicationForm;

namespace MVCBlogApp.UI.Controllers
{
    public class UIWorkshopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public UIWorkshopController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        [Route("seminer-etkinlik-takvimi")]
        [Route("seminar-event-calendar")]
        public async Task<IActionResult> Index()
        {
            int LangID = _operationService.SessionLangId();

            if (LangID == 2)
            {
                TempData["MetaKey"] = "Seminar Event Calendar";
                TempData["MetaDescription"] = "Seminar Event Calendar";
                TempData["MetaTitle"] = "Seminar Event Calendar";
                TempData["Title"] = "Seminar Event Calendar";

            }
            else
            {
                TempData["MetaKey"] = "Seminer Etkinlik Takvimi";
                TempData["MetaDescription"] = "Seminer Etkinlik Takvimi";
                TempData["MetaTitle"] = "Seminer Etkinlik Takvimi";
                TempData["Title"] = "Seminer Etkinlik Takvimi";
            }

            GetWhereWorkShopQueryRequest request = new();
            GetWhereWorkShopQueryResponse response = await _mediator.Send(request);

            return View(response.Workshops);

        }

        [Route("seminer-basvuru-formu/{id?}")]
        [Route("seminar-application-form/{id?}")]
        public async Task<IActionResult> WorkShopApplicationForm(WorkShopApplicationFormQueryRequest request)
        {
            int LangID = _operationService.SessionLangId();
            if (LangID == 2)
            {
                TempData["MetaKey"] = "Seminar Application Form";
                TempData["MetaDescription"] = "Seminar Application Form";
                TempData["MetaTitle"] = "Seminar Application Form";
                TempData["Title"] = "Seminar Application Form";
            }
            else
            {
                TempData["MetaKey"] = "Seminer Başvuru Formu";
                TempData["MetaDescription"] = "Seminer Başvuru Formu";
                TempData["MetaTitle"] = "Seminer Başvuru Formu";
                TempData["Title"] = "Seminer Başvuru Formu";
            }

            WorkShopApplicationFormQueryResponse response = await _mediator.Send(request);

            ViewBag.Gender = new SelectList(response.Genders, "Id", "Gender");
            ViewBag.HearAboutUs = new SelectList(response.HearAboutUs, "Id", "HearAboutUsname");
            ViewBag.Case = new SelectList(response.Cases, "Id", "CaseName");

            if (request.id == 0 && request.id < 0)
            {
                ViewBag.WorkshopCategory = new SelectList(response.WorkshopCategories, "Id", "WscategoryName");
            }
            else
            {
                ViewBag.WorkshopCategory = new SelectList(response.WorkshopCategories, "Id", "WscategoryName", response.workshopCategoryID.ToString());
                ViewBag.WorkshopEducation = new SelectList(response.WorkshopEducations, "Id", "WsEducationName", response.workshopEducationID.ToString());
                ViewBag.Workshop = new SelectList(response.Workshops, "Id", "Title", request.id.ToString());
            }

            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetWorkshopEducation(int WsCategoryID)
        {
            GetWorkshopEducationQueryRequest request = new() { WsCategoryID = WsCategoryID };
            GetWorkshopEducationQueryResponse response = await _mediator.Send(request);
            var citylist = new SelectList(response.WorkshopEducations, "Id", "WsEducationName");
            return Json(citylist);
        }

        [HttpGet]
        public async Task<JsonResult> GetWorkshop(int WsEducationID)
        {
            GetWorkshopQueryRequest request = new()
            {
                WsEducationID = WsEducationID
            };
            GetWorkshopQueryResponse response = await _mediator.Send(request);
            var citylist = new SelectList(response.Workshops, "Id", "Title");
            return Json(citylist);
        }

        [HttpPost]
        [Route("seminer-basvuru-formu/{id?}")]
        [Route("seminar-application-form/{id?}")]
        public async Task<IActionResult> WorkShopApplicationForm(CreateWorkShopApplicationFormCommandRequest request)
        {
            CreateWorkShopApplicationFormCommandResponse response = await _mediator.Send(request);

            if (response.State)
            {
                ViewBag.Result = "Success";
            }
            else
            {
                ViewBag.Result = "Error";
                return View(request);
            }

            return View();
        }
    }
}
