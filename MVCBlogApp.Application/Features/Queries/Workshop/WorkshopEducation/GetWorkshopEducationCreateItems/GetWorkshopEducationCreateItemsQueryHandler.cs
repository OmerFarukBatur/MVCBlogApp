using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetWorkshopEducationCreateItems
{
    public class GetWorkshopEducationCreateItemsQueryHandler : IRequestHandler<GetWorkshopEducationCreateItemsQueryRequest, GetWorkshopEducationCreateItemsQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetWorkshopEducationCreateItemsQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetWorkshopEducationCreateItemsQueryResponse> Handle(GetWorkshopEducationCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _workshopService.GetWorkshopEducationCreateItemsAsync();
        }
    }
}
