using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.Workshop.GetByIdWorkshop
{
    public class GetByIdWorkshopQueryHandler : IRequestHandler<GetByIdWorkshopQueryRequest, GetByIdWorkshopQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetByIdWorkshopQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetByIdWorkshopQueryResponse> Handle(GetByIdWorkshopQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _workshopService.GetByIdWorkshopAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Languages = null,
                    Navigations = null,
                    Statuses = null,
                    WorkshopEducations = null,
                    WorkshopTypes = null,
                    Workshop = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
