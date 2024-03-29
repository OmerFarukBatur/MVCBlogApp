﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Member.Confession.MemberConfessionCreate;
using MVCBlogApp.Application.Features.Commands.Member.Contact.MemberContactCreate;
using MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoCreate;
using MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoUpdate;
using MVCBlogApp.Application.Features.Queries.Member.Confession.GetMemberConfessionCreateItems;
using MVCBlogApp.Application.Features.Queries.Member.Contact.GetMemberContactCreateItems;
using MVCBlogApp.Application.Features.Queries.Member.Dashboard;
using MVCBlogApp.Application.Features.Queries.Member.MemberAppointment.GetByIdMemberAllAppointment;
using MVCBlogApp.Application.Features.Queries.Member.MemberAppointment.GetByIdMemberByIdAppointmentDetail;
using MVCBlogApp.Application.Features.Queries.Member.MemberInfo.GetByIdMemberInfo;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Danışan")]
    public class MemberController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public MemberController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        public async Task<IActionResult> Index()
        {
            GetByIdMemberInfoQueryRequest request = new GetByIdMemberInfoQueryRequest();
            request.Id = _operationService.GetUser().Id;
            GetByIdMemberInfoQueryResponse response = await _mediator.Send(request);

            if (response.State)
            {
                GetMemberDashboardItemListQueryRequest getMemberDashboard = new();
                getMemberDashboard.Id = _operationService.GetUser().Id;
                GetMemberDashboardItemListQueryResponse ıtemListQueryResponse = await _mediator.Send(getMemberDashboard);
                return View(ıtemListQueryResponse);
            }
            else
            {
                return RedirectToAction("MemberInfoCreate", "Member");
            }            
        }

        #region MemberInfo

        [HttpGet]
        public async Task<IActionResult> MemberInfoView(GetByIdMemberInfoQueryRequest request)
        {
            request.Id = _operationService.GetUser().Id;
            GetByIdMemberInfoQueryResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return View(response.MemberAllDetail);
            }
            else
            {
                return RedirectToAction("MemberInfoCreate", "Member");
            }            
        }

        [HttpGet]
        public IActionResult MemberInfoCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MemberInfoCreate(MemberInfoCreateCommandRequest request)
        {
            request.MembersId = _operationService.GetUser().Id;
            MemberInfoCreateCommandResponse response = await _mediator.Send(request);            
            if (response.State)
            {
                return RedirectToAction("Index", "Member");
            }
            else
            {
                return RedirectToAction("MemberInfoCreate", "Member");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> MemberInfoUpdate(MemberInfoUpdateCommandRequest request)
        {
            request.MembersId = _operationService.GetUser().Id;
            MemberInfoUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("Index", "Member");
            }
            else
            {
                return RedirectToAction("MemberInfoView", "Member");
            }
        }

        #endregion

        #region MemberAppointment

        [HttpGet]
        public async Task<IActionResult> MemberByIdAppointmentList(GetByIdMemberAllAppointmentQueryRequest request)
        {
            request.MemberId = _operationService.GetUser().Id;
            GetByIdMemberAllAppointmentQueryResponse response = await _mediator.Send(request);
            return View(response.D_Appointments);
        }

        [HttpGet]
        public async Task<IActionResult> MemberByIdAppointmentDetail(GetByIdMemberByIdAppointmentDetailQueryRequest request)
        {
            GetByIdMemberByIdAppointmentDetailQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("MemberByIdAppointmentList", "Member");
            }
        }

        #endregion

        #region Contact

        [HttpGet]
        public async Task<IActionResult> MemberContactCreate(GetMemberContactCreateItemsQueryRequest request)
        {
            request.MemberId = _operationService.GetUser().Id;
            GetMemberContactCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> MemberContactCreate(MemberContactCreateCommandRequest request)
        {
            MemberContactCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("Index", "Member");
            }
            else
            {
                return RedirectToAction("MemberContactCreate", "Member");
            }            
        }
        
        #endregion

        #region Confession

        [HttpGet]
        public async Task<IActionResult> MemberConfessionCreate(GetMemberConfessionCreateItemsQueryRequest request)
        {
            request.MemberId = _operationService.GetUser().Id;
            GetMemberConfessionCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> MemberConfessionCreate(MemberConfessionCreateCommandRequest request)
        {
            MemberConfessionCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("Index", "Member");
            }
            else
            {
                return RedirectToAction("MemberConfessionCreate", "Member");
            }
        }
        
        #endregion
    }
}
