using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryDelete
{
    public class EventCategoryDeleteCommandHandler : IRequestHandler<EventCategoryDeleteCommandRequest, EventCategoryDeleteCommandResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public EventCategoryDeleteCommandHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<EventCategoryDeleteCommandResponse> Handle(EventCategoryDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _adminGeneralProcess.EventCategoryDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
