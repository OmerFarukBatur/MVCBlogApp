using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkShopApplicationForm.GetByIdWSAFDetail
{
    public class GetByIdWSAFDetailQueryHandler : IRequestHandler<GetByIdWSAFDetailQueryRequest, GetByIdWSAFDetailQueryResponse>
    {
        private readonly IWorkshopService _workshopService;

        public GetByIdWSAFDetailQueryHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<GetByIdWSAFDetailQueryResponse> Handle(GetByIdWSAFDetailQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _workshopService.GetByIdWSAFDetailAsync(request.Id);
            }
            else
            {
                return new()
                {
                    WorkShopApplicationForm = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
