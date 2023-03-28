using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetByIdSeminarVisual
{
    public class GetByIdSeminarVisualQueryHandler : IRequestHandler<GetByIdSeminarVisualQueryRequest, GetByIdSeminarVisualQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetByIdSeminarVisualQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetByIdSeminarVisualQueryResponse> Handle(GetByIdSeminarVisualQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _referenceService.GetByIdSeminarVisualAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Statuses = null,
                    Languages = null,
                    SeminarVisuals = null,
                    State = false,
                    Message = "Lütfen geçerli değerler giriniz."
                };
            }
        }
    }
}
