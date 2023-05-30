using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Admin.Event.GetAllEvent
{
    public class GetAllEventQueryHandler : IRequestHandler<GetAllEventQueryRequest, GetAllEventQueryResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public GetAllEventQueryHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<GetAllEventQueryResponse> Handle(GetAllEventQueryRequest request, CancellationToken cancellationToken)
        {
            return await _adminGeneralProcess.GetAllEventAsync();
        }
    }
}
