using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeCreate
{
    public class WorkshopTypeCreateCommandHandler : IRequestHandler<WorkshopTypeCreateCommandRequest, WorkshopTypeCreateCommandResponse>
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopTypeCreateCommandHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<WorkshopTypeCreateCommandResponse> Handle(WorkshopTypeCreateCommandRequest request, CancellationToken cancellationToken)
        {
            WorkshopTypeCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _workshopService.WorkshopTypeCreateAsync(request);
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
