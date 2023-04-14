using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetAllWorkshopType
{
    public class GetAllWorkshopTypeQueryHandler : IRequestHandler<GetAllWorkshopTypeQueryRequest, GetAllWorkshopTypeQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetAllWorkshopTypeQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetAllWorkshopTypeQueryResponse> Handle(GetAllWorkshopTypeQueryRequest request, CancellationToken cancellationToken)
        {
            return await _workshopService.GetAllWorkshopTypeAsync();
        }
    }
}
