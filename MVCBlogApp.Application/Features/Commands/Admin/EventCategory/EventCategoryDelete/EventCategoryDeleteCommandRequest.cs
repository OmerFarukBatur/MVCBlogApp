using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryDelete
{
    public class EventCategoryDeleteCommandRequest : IRequest<EventCategoryDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}