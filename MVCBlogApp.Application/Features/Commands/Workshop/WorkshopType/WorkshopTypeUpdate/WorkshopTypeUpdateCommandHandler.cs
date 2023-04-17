using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeUpdate
{
    public class WorkshopTypeUpdateCommandHandler : IRequestHandler<WorkshopTypeUpdateCommandRequest, WorkshopTypeUpdateCommandResponse>
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopTypeUpdateCommandHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<WorkshopTypeUpdateCommandResponse> Handle(WorkshopTypeUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            WorkshopTypeUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _workshopService.WorkshopTypeUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
