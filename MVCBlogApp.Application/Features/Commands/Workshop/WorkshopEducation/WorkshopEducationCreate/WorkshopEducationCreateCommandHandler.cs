using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationCreate
{
    public class WorkshopEducationCreateCommandHandler : IRequestHandler<WorkshopEducationCreateCommandRequest, WorkshopEducationCreateCommandResponse>
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopEducationCreateCommandHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<WorkshopEducationCreateCommandResponse> Handle(WorkshopEducationCreateCommandRequest request, CancellationToken cancellationToken)
        {
            WorkshopEducationCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _workshopService.WorkshopEducationCreateAsync(request);
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
