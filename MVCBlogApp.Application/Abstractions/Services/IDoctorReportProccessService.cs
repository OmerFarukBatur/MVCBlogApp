using MVCBlogApp.Application.Features.Commands.Doctor.AppointmentCreate;
using MVCBlogApp.Application.Features.Queries.Doctor.GetAllAppointment;
using MVCBlogApp.Application.Features.Queries.Doctor.GetAppointmentCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IDoctorReportProccessService
    {
        #region Appointment

        Task<GetAppointmentCreateItemsQueryResponse> GetAppointmentCreateItemsAsync();
        Task<GetAllAppointmentQueryResponse> GetAllAppointmentAsync(); 
        Task<AppointmentCreateCommandResponse> AppointmentCreateAsync(AppointmentCreateCommandRequest request);

        #endregion
    }
}
