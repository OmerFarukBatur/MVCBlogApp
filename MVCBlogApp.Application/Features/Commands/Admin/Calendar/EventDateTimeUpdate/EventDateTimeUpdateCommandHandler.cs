using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Admin.Calendar.EventDateTimeUpdate
{
    public class EventDateTimeUpdateCommandHandler : IRequestHandler<EventDateTimeUpdateCommandRequest, EventDateTimeUpdateCommandResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public EventDateTimeUpdateCommandHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<EventDateTimeUpdateCommandResponse> Handle(EventDateTimeUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            EventDateTimeUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _adminGeneralProcess.EventDateTimeAsync(request);
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
