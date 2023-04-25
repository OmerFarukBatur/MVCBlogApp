using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Workshop.Workshop.WorkshopDelete
{
    public class WorkshopDeleteCommandHandler : IRequestHandler<WorkshopDeleteCommandRequest, WorkshopDeleteCommandResponse>
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopDeleteCommandHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<WorkshopDeleteCommandResponse> Handle(WorkshopDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _workshopService.WorkshopDeleteAsync(request.Id);
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
