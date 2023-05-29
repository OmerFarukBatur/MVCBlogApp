using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetAllEventCategory
{
    public class GetAllEventCategoryQueryHandler : IRequestHandler<GetAllEventCategoryQueryRequest, GetAllEventCategoryQueryResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public GetAllEventCategoryQueryHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<GetAllEventCategoryQueryResponse> Handle(GetAllEventCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            return await _adminGeneralProcess.GetAllEventCategoryAsync();
        }
    }
}
