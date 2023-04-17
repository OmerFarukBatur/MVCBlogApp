using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetAllWorkshopEducation
{
    public class GetAllWorkshopEducationQueryHandler : IRequestHandler<GetAllWorkshopEducationQueryRequest, GetAllWorkshopEducationQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetAllWorkshopEducationQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetAllWorkshopEducationQueryResponse> Handle(GetAllWorkshopEducationQueryRequest request, CancellationToken cancellationToken)
        {
            return await _workshopService.GetAllWorkshopEducationAsync();
        }
    }
}
