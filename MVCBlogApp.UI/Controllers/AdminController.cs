﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetAllEventCategory;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryCreate;

namespace MVCBlogApp.UI.Controllers
{
    //[Authorize(Roles ="Admin")]
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
        public async Task<IActionResult> EventList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EventCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EventCreate(int a)
        {
            return View();
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
        public async Task<IActionResult> EventCategoryUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EventCategoryUpdate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EventCategoryDelete()
        {
            return View();
        }

        #endregion

        #endregion
    }
}
