using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetAllAppointmentDetail
{
    public class GetAllAppointmentDetailQueryHandler : IRequestHandler<GetAllAppointmentDetailQueryRequest, GetAllAppointmentDetailQueryResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public GetAllAppointmentDetailQueryHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<GetAllAppointmentDetailQueryResponse> Handle(GetAllAppointmentDetailQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAppointmentDetailAsync();
        }
    }
}
