using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.GetByIdAppointment
{
    public class GetByIdAppointmentQueryHandler : IRequestHandler<GetByIdAppointmentQueryRequest, GetByIdAppointmentQueryResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public GetByIdAppointmentQueryHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<GetByIdAppointmentQueryResponse> Handle(GetByIdAppointmentQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _service.GetByIdAppointmentAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Admins = null,
                    Members = null,
                    Statuses = null,
                    D_Appointment = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
