﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.ByIdAppointmentDateTimeUpdate;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetAllAppointment;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetAppointmentCreateItems;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetByIdAppointment;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetCalenderEventList;
using MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetAppointmentDetailCreateItems;
using NuGet.Protocol;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Diyetisyen")]
    public class DoctorReportProccessController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public DoctorReportProccessController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        #region Appointment

        [HttpGet]
        public async Task<IActionResult> AppointmentList(GetAllAppointmentQueryRequest request)
        {
            GetAllAppointmentQueryResponse response = await _mediator.Send(request);
            return View(response.D_Appointments);
        }

        [HttpGet]
        public async Task<IActionResult> AppointmentCreate(GetAppointmentCreateItemsQueryRequest request)
        {
            GetAppointmentCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AppointmentCreate(AppointmentCreateCommandRequest request)
        {
            request.CreateUserId = _operationService.GetUser().Id;
            AppointmentCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("AppointmentList", "DoctorReportProccess");
            }
            else
            {
                return RedirectToAction("AppointmentCreate", "DoctorReportProccess");
            }
        }

        [HttpGet]
        public async Task<IActionResult> AppointmentUpdate(GetByIdAppointmentQueryRequest request)
        {
            GetByIdAppointmentQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("AppointmentList", "DoctorReportProccess");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AppointmentUpdate(AppointmentUpdateCommandRequest request)
        {
            AppointmentUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("AppointmentList", "DoctorReportProccess");
            }
            else
            {
                return RedirectToAction("AppointmentUpdate", "DoctorReportProccess");
            }
        }

        public async Task<IActionResult> AppointmentDelete(AppointmentDeleteCommandRequest request)
        {
            AppointmentDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("AppointmentList", "DoctorReportProccess");
        }

        
        public async Task<IActionResult> CalenderEventList(GetCalenderEventListQueryRequest request)
        {
            GetCalenderEventListQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> ByIdAppointmentDateTimeUpdate(ByIdAppointmentDateTimeUpdateCommandRequest request)
        {
            ByIdAppointmentDateTimeUpdateCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ByIdAppointmentStatusUpdate(AppointmentDeleteCommandRequest request)
        {
            AppointmentDeleteCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        #endregion

        #region AppointmentDetail

        [HttpGet]
        public async Task<IActionResult> AppointmentDetailList(GetAllAppointmentQueryRequest request)
        {
            GetAllAppointmentQueryResponse response = await _mediator.Send(request);
            return View(response.D_Appointments);
        }

        [HttpGet]
        public async Task<IActionResult> AppointmentDetailCreate(GetAppointmentDetailCreateItemsQueryRequest request)
        {
            GetAppointmentDetailCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AppointmentDetailCreate(AppointmentCreateCommandRequest request)
        {
            
            AppointmentCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("AppointmentList", "DoctorReportProccess");
            }
            else
            {
                return RedirectToAction("AppointmentCreate", "DoctorReportProccess");
            }
        }

        [HttpGet]
        public async Task<IActionResult> AppointmentDetailUpdate(GetByIdAppointmentQueryRequest request)
        {
            GetByIdAppointmentQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("AppointmentList", "DoctorReportProccess");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AppointmentDetailUpdate(AppointmentUpdateCommandRequest request)
        {
            AppointmentUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("AppointmentList", "DoctorReportProccess");
            }
            else
            {
                return RedirectToAction("AppointmentUpdate", "DoctorReportProccess");
            }
        }

        public async Task<IActionResult> AppointmentDetailDelete(AppointmentDeleteCommandRequest request)
        {
            AppointmentDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("AppointmentList", "DoctorReportProccess");
        }
        
        #endregion
    }
}
