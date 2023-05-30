using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Admin.Event.EventDelete
{
    public class EventDeleteCommandHandler : IRequestHandler<EventDeleteCommandRequest, EventDeleteCommandResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public EventDeleteCommandHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<EventDeleteCommandResponse> Handle(EventDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _adminGeneralProcess.EventDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
