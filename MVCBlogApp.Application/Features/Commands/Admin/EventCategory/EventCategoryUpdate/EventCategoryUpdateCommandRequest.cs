using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryUpdate
{
    public class EventCategoryUpdateCommandRequest : IRequest<EventCategoryUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string EventCategoryName { get; set; }
    }
}