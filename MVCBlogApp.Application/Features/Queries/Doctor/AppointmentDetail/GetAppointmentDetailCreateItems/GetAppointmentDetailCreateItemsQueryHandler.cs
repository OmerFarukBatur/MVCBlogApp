using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetAppointmentDetailCreateItems
{
    public class GetAppointmentDetailCreateItemsQueryHandler : IRequestHandler<GetAppointmentDetailCreateItemsQueryRequest, GetAppointmentDetailCreateItemsQueryResponse>
    {
        private IDoctorReportProccessService _service;

        public GetAppointmentDetailCreateItemsQueryHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<GetAppointmentDetailCreateItemsQueryResponse> Handle(GetAppointmentDetailCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetAppointmentDetailCreateItemsAsync();
        }
    }
}
