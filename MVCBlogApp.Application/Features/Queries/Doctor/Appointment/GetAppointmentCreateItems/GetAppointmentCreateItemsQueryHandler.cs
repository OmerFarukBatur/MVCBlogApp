using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetAppointmentCreateItems
{
    public class GetAppointmentCreateItemsQueryHandler : IRequestHandler<GetAppointmentCreateItemsQueryRequest, GetAppointmentCreateItemsQueryResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public GetAppointmentCreateItemsQueryHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<GetAppointmentCreateItemsQueryResponse> Handle(GetAppointmentCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetAppointmentCreateItemsAsync();
        }
    }
}
