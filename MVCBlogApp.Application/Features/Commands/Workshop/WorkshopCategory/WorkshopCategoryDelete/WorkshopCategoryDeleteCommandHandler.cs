using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryDelete
{
    public class WorkshopCategoryDeleteCommandHandler : IRequestHandler<WorkshopCategoryDeleteCommandRequest, WorkshopCategoryDeleteCommandResponse>
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopCategoryDeleteCommandHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<WorkshopCategoryDeleteCommandResponse> Handle(WorkshopCategoryDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _workshopService.WorkshopCategoryDeleteAsync(request.Id);
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
