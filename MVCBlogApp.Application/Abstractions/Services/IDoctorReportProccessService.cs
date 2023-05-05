using MVCBlogApp.Application.Features.Commands.Doctor.AppointmentCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.AppointmentUpdate;
using MVCBlogApp.Application.Features.Queries.Doctor.GetAllAppointment;
using MVCBlogApp.Application.Features.Queries.Doctor.GetAppointmentCreateItems;
using MVCBlogApp.Application.Features.Queries.Doctor.GetByIdAppointment;
using MVCBlogApp.Application.Features.Queries.Doctor.GetCalenderEventList;

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

        #endregion
    }
}
