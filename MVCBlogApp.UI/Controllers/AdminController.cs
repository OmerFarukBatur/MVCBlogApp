﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Admin.Calendar.EventDateTimeUpdate;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventCreate;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventDelete;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventUpdate;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.Admin.Calendar.GetAllCalendarEvent;
using MVCBlogApp.Application.Features.Queries.Admin.Dashboard;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetAllEvent;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetByIdEvent;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetEventCreateItems;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetAllEventCategory;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetByIdEventCategory;

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
        [Route("Admin/Index")]
        public async Task<IActionResult> Index(GetDashboardItemListQueryRequest request)
        {
            GetDashboardItemListQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        #region Calendar Islemleri

        #region Calendar

        public async Task<IActionResult> Calendar(GetAllCalendarEventQueryRequest request)
        {
            GetAllCalendarEventQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> EventDateTimeUpdate(EventDateTimeUpdateCommandRequest request)
        {
            EventDateTimeUpdateCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        public async Task<IActionResult> EventStatusUpdate(EventDeleteCommandRequest request)
        {
            EventDeleteCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        #endregion

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
            request.CreateUserId = _operationService.GetUser().Id;
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
        public async Task<IActionResult> EventUpdate(GetByIdEventQueryRequest request)
        {
            GetByIdEventQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("EventList", "Admin");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EventUpdate(EventUpdateCommandRequest request)
        {
            EventUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("EventList", "Admin");
            }
            else
            {
                return RedirectToAction("EventUpdate", "Admin");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EventDelete(EventDeleteCommandRequest request)
        {
            EventDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("EventList", "Admin");
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
