using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.IUWorkShop.WorkShopApplicationForm
{
    public class WorkShopApplicationFormQueryHandler : IRequestHandler<WorkShopApplicationFormQueryRequest, WorkShopApplicationFormQueryResponse>
    {
        private readonly IUIOtherService _uIOtherService;

        public WorkShopApplicationFormQueryHandler(IUIOtherService uIOtherService)
        {
            _uIOtherService = uIOtherService;
        }

        public async Task<WorkShopApplicationFormQueryResponse> Handle(WorkShopApplicationFormQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uIOtherService.WorkShopApplicationFormAsync(request);
        }
    }
}
