using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Admin.Event.GetByIdEvent
{
    public class GetByIdEventQueryHandler : IRequestHandler<GetByIdEventQueryRequest, GetByIdEventQueryResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public GetByIdEventQueryHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<GetByIdEventQueryResponse> Handle(GetByIdEventQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _adminGeneralProcess.GetByIdEventAsync(request.Id);
            }
            else
            {
                return new()
                {
                    EventCategories = null,
                    Statuses = null,
                    Event = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
