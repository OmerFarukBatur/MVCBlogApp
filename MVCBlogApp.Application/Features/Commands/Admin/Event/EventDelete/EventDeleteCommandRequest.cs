using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Admin.Event.EventDelete
{
    public class EventDeleteCommandRequest : IRequest<EventDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}