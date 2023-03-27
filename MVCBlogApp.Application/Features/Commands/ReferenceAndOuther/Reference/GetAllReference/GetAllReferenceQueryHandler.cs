using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.GetAllReference
{
    public class GetAllReferenceQueryHandler : IRequestHandler<GetAllReferenceQueryRequest, GetAllReferenceQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetAllReferenceQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetAllReferenceQueryResponse> Handle(GetAllReferenceQueryRequest request, CancellationToken cancellationToken)
        {
            return await _referenceService.GetAllReferenceAsync();
        }
    }
}
