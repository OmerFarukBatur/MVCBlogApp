using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationUpdate
{
    public class WorkshopEducationUpdateCommandHandler : IRequestHandler<WorkshopEducationUpdateCommandRequest, WorkshopEducationUpdateCommandResponse>
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopEducationUpdateCommandHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<WorkshopEducationUpdateCommandResponse> Handle(WorkshopEducationUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            WorkshopEducationUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _workshopService.WorkshopEducationUpdateAsync(request);
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
