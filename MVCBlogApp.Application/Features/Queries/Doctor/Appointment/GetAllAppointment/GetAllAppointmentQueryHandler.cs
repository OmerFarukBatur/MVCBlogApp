using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetAllAppointment
{
    public class GetAllAppointmentQueryHandler : IRequestHandler<GetAllAppointmentQueryRequest, GetAllAppointmentQueryResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public GetAllAppointmentQueryHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<GetAllAppointmentQueryResponse> Handle(GetAllAppointmentQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAppointmentAsync();
        }
    }
}
