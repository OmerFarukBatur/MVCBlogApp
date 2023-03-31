using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetByIdPress
{
    public class GetByIdPressQueryHandler : IRequestHandler<GetByIdPressQueryRequest, GetByIdPressQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetByIdPressQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetByIdPressQueryResponse> Handle(GetByIdPressQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _referenceService.GetByIdPressAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Languages = null,
                    NewsPapers = null,
                    PressTypes = null,
                    Statuses = null,
                    Press = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
