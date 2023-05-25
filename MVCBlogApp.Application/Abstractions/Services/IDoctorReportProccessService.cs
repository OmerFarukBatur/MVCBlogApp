using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.ByIdAppointmentDateTimeUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDetail.AppointmentDetailCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDetail.AppointmentDetailDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDetail.AppointmentDetailUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesUpdate;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetAllAppointment;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetAppointmentCreateItems;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetByIdAppointment;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetCalenderEventList;
using MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetAllAppointmentDetail;
using MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetAppointmentDetailCreateItems;
using MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetByIdAppointmentDetail;
using MVCBlogApp.Application.Features.Queries.Doctor.Diseases.GetAllDiseases;
using MVCBlogApp.Application.Features.Queries.Doctor.Diseases.GetByIdDiseases;

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
        Task<GetAllAppointmentDetailQueryResponse> GetAllAppointmentDetailAsync();
        Task<AppointmentDetailCreateCommandResponse> AppointmentDetailCreateAsync(AppointmentDetailCreateCommandRequest request);
        Task<GetByIdAppointmentDetailQueryResponse> GetByIdAppointmentDetailQueryResponse(int id);
        Task<AppointmentDetailUpdateCommandResponse> AppointmentDetailUpdateAsync(AppointmentDetailUpdateCommandRequest request);
        Task<AppointmentDetailDeleteCommandResponse> AppointmentDetailDeleteAsync(int id);

        #endregion

        #region Diseases

        Task<GetAllDiseasesQueryResponse> GetAllDiseasesAsync();
        Task<DiseasesCreateCommandResponse> DiseasesCreateAsync(DiseasesCreateCommandRequest request);
        Task<GetByIdDiseasesQueryResponse> GetByIdDiseasesAsync(int id);
        Task<DiseasesUpdateCommandResponse> DiseasesUpdateAsync(DiseasesUpdateCommandRequest request);
        Task<DiseasesDeleteCommandResponse> DiseasesDeleteAsync(int id);

        #endregion
    }
}
