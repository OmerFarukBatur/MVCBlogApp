using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryUpdate
{
    public class WorkshopCategoryUpdateCommandHandler : IRequestHandler<WorkshopCategoryUpdateCommandRequest, WorkshopCategoryUpdateCommandResponse>
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopCategoryUpdateCommandHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<WorkshopCategoryUpdateCommandResponse> Handle(WorkshopCategoryUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            WorkshopCategoryUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _workshopService.WorkshopCategoryUpdateAsync(request);
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
