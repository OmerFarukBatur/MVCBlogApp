using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.Workshop.GetAllWorkshop
{
    public class GetAllWorkshopQueryHandler : IRequestHandler<GetAllWorkshopQueryRequest, GetAllWorkshopQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetAllWorkshopQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetAllWorkshopQueryResponse> Handle(GetAllWorkshopQueryRequest request, CancellationToken cancellationToken)
        {
            return await _workshopService.GetAllWorkshopAsync();
        }
    }
}
