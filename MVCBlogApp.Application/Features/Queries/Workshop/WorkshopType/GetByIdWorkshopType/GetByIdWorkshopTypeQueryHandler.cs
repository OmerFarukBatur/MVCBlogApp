using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetByIdWorkshopType
{
    public class GetByIdWorkshopTypeQueryHandler : IRequestHandler<GetByIdWorkshopTypeQueryRequest, GetByIdWorkshopTypeQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetByIdWorkshopTypeQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetByIdWorkshopTypeQueryResponse> Handle(GetByIdWorkshopTypeQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _workshopService.GetByIdWorkshopTypeAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Languages = null,
                    WorkshopType = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
