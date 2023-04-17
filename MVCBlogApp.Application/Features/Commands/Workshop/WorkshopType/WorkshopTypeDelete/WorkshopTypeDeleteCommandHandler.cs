using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeDelete
{
    public class WorkshopTypeDeleteCommandHandler : IRequestHandler<WorkshopTypeDeleteCommandRequest, WorkshopTypeDeleteCommandResponse>
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopTypeDeleteCommandHandler(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<WorkshopTypeDeleteCommandResponse> Handle(WorkshopTypeDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _workshopService.WorkshopTypeDeleteAsync(request.Id);
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
