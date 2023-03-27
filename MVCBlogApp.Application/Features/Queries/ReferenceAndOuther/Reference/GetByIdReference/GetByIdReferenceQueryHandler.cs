using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetByIdReference
{
    public class GetByIdReferenceQueryHandler : IRequestHandler<GetByIdReferenceQueryRequest, GetByIdReferenceQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetByIdReferenceQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetByIdReferenceQueryResponse> Handle(GetByIdReferenceQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _referenceService.GetByIdReferenceAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli değerler giriniz.",
                    References = null,
                    State = false,
                    Statuses = null
                };
            }
        }
    }
}
