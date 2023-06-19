using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Dashboard
{
    public class GetDoctorDashboardItemListQueryHandler : IRequestHandler<GetDoctorDashboardItemListQueryRequest, GetDoctorDashboardItemListQueryResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public GetDoctorDashboardItemListQueryHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<GetDoctorDashboardItemListQueryResponse> Handle(GetDoctorDashboardItemListQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetDoctorDashboardItemListAsync(request.Id);
        }
    }
}
