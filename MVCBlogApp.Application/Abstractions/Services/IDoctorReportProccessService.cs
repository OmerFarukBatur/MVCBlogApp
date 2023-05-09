﻿using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.ByIdAppointmentDateTimeUpdate;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetAllAppointment;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetAppointmentCreateItems;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetByIdAppointment;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetCalenderEventList;
using MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetAppointmentDetailCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IDoctorReportProccessService
    {
        #region Appointment

        Task<GetAppointmentCreateItemsQueryResponse> GetAppointmentCreateItemsAsync();
        Task<GetAllAppointmentQueryResponse> GetAllAppointmentAsync(); 
        Task<AppointmentCreateCommandResponse> AppointmentCreateAsync(AppointmentCreateCommandRequest request);
        Task<GetByIdAppointmentQueryResponse> GetByIdAppointmentAsync(int id);
        Task<AppointmentUpdateCommandResponse> AppointmentUpdateAsync(AppointmentUpdateCommandRequest request);
        Task<AppointmentDeleteCommandResponse> AppointmentDeleteAsync(int id);
        Task<GetCalenderEventListQueryResponse> GetCalenderEventListAsync();
        Task<ByIdAppointmentDateTimeUpdateCommandResponse> ByIdAppointmentDateTimeUpdateAsync(ByIdAppointmentDateTimeUpdateCommandRequest request);

        #endregion

        #region AppointmentDetail

        Task<GetAppointmentDetailCreateItemsQueryResponse> GetAppointmentDetailCreateItemsAsync();

        #endregion
    }
}
