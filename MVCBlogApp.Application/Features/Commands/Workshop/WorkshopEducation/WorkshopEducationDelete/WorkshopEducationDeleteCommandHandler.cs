using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationDelete
{
    public class WorkshopEducationDeleteCommandHandler : IRequestHandler<WorkshopEducationDeleteCommandRequest, WorkshopEducationDeleteCommandResponse>
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopEducationDeleteCommandHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<WorkshopEducationDeleteCommandResponse> Handle(WorkshopEducationDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _workshopService.WorkshopEducationDeleteAsync(request.Id);
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
