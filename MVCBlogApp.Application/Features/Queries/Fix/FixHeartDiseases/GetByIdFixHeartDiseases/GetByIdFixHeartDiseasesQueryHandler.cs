using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetByIdFixHeartDiseases
{
    public class GetByIdFixHeartDiseasesQueryHandler : IRequestHandler<GetByIdFixHeartDiseasesQueryRequest, GetByIdFixHeartDiseasesQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetByIdFixHeartDiseasesQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetByIdFixHeartDiseasesQueryResponse> Handle(GetByIdFixHeartDiseasesQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.GetByIdFixHeartDiseasesAsync(request.Id);
            }
            else
            {
                return new()
                {
                    FixHeartDiseases = null,
                    Forms = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
