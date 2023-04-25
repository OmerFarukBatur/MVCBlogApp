using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkShopApplicationForm.GetAllWSAF
{
    public class GetAllWSAFQueryHandler : IRequestHandler<GetAllWSAFQueryRequest, GetAllWSAFQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetAllWSAFQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetAllWSAFQueryResponse> Handle(GetAllWSAFQueryRequest request, CancellationToken cancellationToken)
        {
            return await _workshopService.GetAllWSAFAsync();
        }
    }
}
