using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetByIdEventCategory
{
    public class GetByIdEventCategoryQueryHandler : IRequestHandler<GetByIdEventCategoryQueryRequest, GetByIdEventCategoryQueryResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public GetByIdEventCategoryQueryHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<GetByIdEventCategoryQueryResponse> Handle(GetByIdEventCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _adminGeneralProcess.GetByIdEventCategoryAsync(request.Id);
            }
            else
            {
                return new()
                {
                    EventCategory = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
