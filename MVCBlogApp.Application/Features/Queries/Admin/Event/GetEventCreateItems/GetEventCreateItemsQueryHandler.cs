using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Admin.Event.GetEventCreateItems
{
    public class GetEventCreateItemsQueryHandler : IRequestHandler<GetEventCreateItemsQueryRequest, GetEventCreateItemsQueryResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public GetEventCreateItemsQueryHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<GetEventCreateItemsQueryResponse> Handle(GetEventCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _adminGeneralProcess.GetEventCreateItemsAsync();
        }
    }
}
