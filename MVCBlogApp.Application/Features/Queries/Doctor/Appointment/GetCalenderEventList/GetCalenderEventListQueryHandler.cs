using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetCalenderEventList
{
    public class GetCalenderEventListQueryHandler : IRequestHandler<GetCalenderEventListQueryRequest, GetCalenderEventListQueryResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public GetCalenderEventListQueryHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<GetCalenderEventListQueryResponse> Handle(GetCalenderEventListQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetCalenderEventListAsync();
        }
    }
}
