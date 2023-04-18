using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetByIdWorkshopEducation
{
    public class GetByIdWorkshopEducationQueryHandler : IRequestHandler<GetByIdWorkshopEducationQueryRequest, GetByIdWorkshopEducationQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetByIdWorkshopEducationQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetByIdWorkshopEducationQueryResponse> Handle(GetByIdWorkshopEducationQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _workshopService.GetByIdWorkshopEducationAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Languages = null,
                    Statuses = null,
                    WorkshopCategories = null,
                    WorkshopEducation = null,
                    State = false,
                    Message = "Kayıt bulunamadı."
                };
            }
        }
    }
}
