using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetWorkshopTypeCreateItems
{
    public class GetWorkshopTypeCreateItemsQueryHandler : IRequestHandler<GetWorkshopTypeCreateItemsQueryRequest, GetWorkshopTypeCreateItemsQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetWorkshopTypeCreateItemsQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetWorkshopTypeCreateItemsQueryResponse> Handle(GetWorkshopTypeCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _workshopService.GetWorkshopTypeCreateItemsAsync();
        }
    }
}
