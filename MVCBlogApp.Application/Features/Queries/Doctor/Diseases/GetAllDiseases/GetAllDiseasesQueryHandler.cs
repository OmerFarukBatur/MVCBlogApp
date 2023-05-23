using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Diseases.GetAllDiseases
{
    public class GetAllDiseasesQueryHandler : IRequestHandler<GetAllDiseasesQueryRequest, GetAllDiseasesQueryResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public GetAllDiseasesQueryHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<GetAllDiseasesQueryResponse> Handle(GetAllDiseasesQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetAllDiseasesAsync();
        }
    }
}
