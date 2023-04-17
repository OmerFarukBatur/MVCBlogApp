using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeDelete
{
    public class WorkshopTypeDeleteCommandRequest : IRequest<WorkshopTypeDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}