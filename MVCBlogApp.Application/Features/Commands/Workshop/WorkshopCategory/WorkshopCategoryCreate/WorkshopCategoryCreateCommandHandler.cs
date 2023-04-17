using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryCreate
{
    public class WorkshopCategoryCreateCommandHandler : IRequestHandler<WorkshopCategoryCreateCommandRequest, WorkshopCategoryCreateCommandResponse>
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopCategoryCreateCommandHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<WorkshopCategoryCreateCommandResponse> Handle(WorkshopCategoryCreateCommandRequest request, CancellationToken cancellationToken)
        {
            WorkshopCategoryCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _workshopService.WorkshopCategoryCreateAsync(request);
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
