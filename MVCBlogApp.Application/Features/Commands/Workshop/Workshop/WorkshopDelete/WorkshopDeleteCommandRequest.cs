using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Workshop.Workshop.WorkshopDelete
{
    public class WorkshopDeleteCommandRequest : IRequest<WorkshopDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}