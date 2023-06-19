using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Admin.Header
{
    public class GetAdminHeaderDataQueryHandler : IRequestHandler<GetAdminHeaderDataQueryRequest, GetAdminHeaderDataQueryResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public GetAdminHeaderDataQueryHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<GetAdminHeaderDataQueryResponse> Handle(GetAdminHeaderDataQueryRequest request, CancellationToken cancellationToken)
        {
            return await _adminGeneralProcess.GetAdminHeaderDataAsync();
        }
    }
}
