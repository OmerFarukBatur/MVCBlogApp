using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetAllWorkshopCategory
{
    public class GetAllWorkshopCategoryQueryHandler : IRequestHandler<GetAllWorkshopCategoryQueryRequest, GetAllWorkshopCategoryQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetAllWorkshopCategoryQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetAllWorkshopCategoryQueryResponse> Handle(GetAllWorkshopCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            return await _workshopService.GetAllWorkshopCategoryAsync();
        }
    }
}
