using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetByIdWorkshopCategory
{
    public class GetByIdWorkshopCategoryQueryHandler : IRequestHandler<GetByIdWorkshopCategoryQueryRequest, GetByIdWorkshopCategoryQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetByIdWorkshopCategoryQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetByIdWorkshopCategoryQueryResponse> Handle(GetByIdWorkshopCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _workshopService.GetByIdWorkshopCategoryAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Languages = null,
                    WorkshopCategory = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
