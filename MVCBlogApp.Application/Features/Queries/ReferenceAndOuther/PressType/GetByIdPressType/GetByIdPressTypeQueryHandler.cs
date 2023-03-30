using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.PressType.GetByIdPressType
{
    public class GetByIdPressTypeQueryHandler : IRequestHandler<GetByIdPressTypeQueryRequest, GetByIdPressTypeQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetByIdPressTypeQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetByIdPressTypeQueryResponse> Handle(GetByIdPressTypeQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _referenceService.GetByIdPressTypeAsync(request.Id);
            }
            else
            {
                return new()
                {
                    PressType = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
