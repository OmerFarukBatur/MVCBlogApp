using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Workshop.Workshop.WorkshopCreate
{
    public class WorkshopCreateCommandHandler : IRequestHandler<WorkshopCreateCommandRequest, WorkshopCreateCommandResponse>
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopCreateCommandHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<WorkshopCreateCommandResponse> Handle(WorkshopCreateCommandRequest request, CancellationToken cancellationToken)
        {
            WorkshopCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _workshopService.WorkshopCreateAsync(request);
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
