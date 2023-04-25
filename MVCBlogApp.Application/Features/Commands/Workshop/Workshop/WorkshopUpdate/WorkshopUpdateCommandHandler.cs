using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Workshop.Workshop.WorkshopUpdate
{
    public class WorkshopUpdateCommandHandler : IRequestHandler<WorkshopUpdateCommandRequest, WorkshopUpdateCommandResponse>
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopUpdateCommandHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<WorkshopUpdateCommandResponse> Handle(WorkshopUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            WorkshopUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _workshopService.WorkshopUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli bilgilerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
