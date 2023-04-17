using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetWorkshopCategoryCreateItems
{
    public class GetWorkshopCategoryCreateItemsQueryHandler : IRequestHandler<GetWorkshopCategoryCreateItemsQueryRequest, GetWorkshopCategoryCreateItemsQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetWorkshopCategoryCreateItemsQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetWorkshopCategoryCreateItemsQueryResponse> Handle(GetWorkshopCategoryCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _workshopService.GetWorkshopCategoryCreateItemsAsync();
        }
    }
}
