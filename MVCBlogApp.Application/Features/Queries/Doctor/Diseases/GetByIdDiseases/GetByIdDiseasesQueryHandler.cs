using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Diseases.GetByIdDiseases
{
    public class GetByIdDiseasesQueryHandler : IRequestHandler<GetByIdDiseasesQueryRequest, GetByIdDiseasesQueryResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public GetByIdDiseasesQueryHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<GetByIdDiseasesQueryResponse> Handle(GetByIdDiseasesQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _service.GetByIdDiseasesAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Diseases = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
