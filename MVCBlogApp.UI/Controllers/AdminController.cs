using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetAllEventCategory;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryCreate;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetByIdEventCategory;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryUpdate;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryDelete;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetEventCreateItems;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetAllEvent;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventCreate;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public AdminController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        public async Task<IActionResult> Index()
        {                
            return View();
        }

        #region Calendar

        #region Event

        [HttpGet]
        public async Task<IActionResult> EventList(GetAllEventQueryRequest request)
        {
            GetAllEventQueryResponse response = await _mediator.Send(request);
            return View(response.Events);
        }

        [HttpGet]
        public async Task<IActionResult> EventCreate(GetEventCreateItemsQueryRequest request)
        {
            GetEventCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EventCreate(EventCreateCommandRequest request)
        {
            EventCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("EventList", "Admin");
            }
            else
            {
                return RedirectToAction("EventCreate", "Admin");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EventUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EventUpdate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EventDelete()
        {
            return View();
        }

        #endregion

        #region EventCategory

        [HttpGet]
        public async Task<IActionResult> EventCategoryList(GetAllEventCategoryQueryRequest request)
        {
            GetAllEventCategoryQueryResponse response = await _mediator.Send(request);
            return View(response.EventCategories);
        }

        [HttpGet]
        public IActionResult EventCategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EventCategoryCreate(EventCategoryCreateCommandRequest request)
        {
            EventCategoryCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("EventCategoryList", "Admin");
            }
            else
            {
                return RedirectToAction("EventCategoryCreate", "Admin");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EventCategoryUpdate(GetByIdEventCategoryQueryRequest request)
        {
            GetByIdEventCategoryQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("EventCategoryList", "Admin");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EventCategoryUpdate(EventCategoryUpdateCommandRequest request)
        {
            EventCategoryUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("EventCategoryList", "Admin");
            }
            else
            {
                return RedirectToAction("EventCategoryUpdate", "Admin");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EventCategoryDelete(EventCategoryDeleteCommandRequest request)
        {
            EventCategoryDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("EventCategoryList", "Admin");
        }

        #endregion

        #endregion
    }
}
