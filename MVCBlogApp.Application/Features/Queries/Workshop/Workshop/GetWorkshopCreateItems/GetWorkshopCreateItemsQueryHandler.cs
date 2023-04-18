using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.Workshop.GetWorkshopCreateItems
{
    public class GetWorkshopCreateItemsQueryHandler : IRequestHandler<GetWorkshopCreateItemsQueryRequest, GetWorkshopCreateItemsQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetWorkshopCreateItemsQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetWorkshopCreateItemsQueryResponse> Handle(GetWorkshopCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _workshopService.GetWorkshopCreateItemsAsync();
        }
    }
}
