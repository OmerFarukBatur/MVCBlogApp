using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryCreate
{
    public class EventCategoryCreateCommandRequest : IRequest<EventCategoryCreateCommandResponse>
    {
        public string EventCategoryName { get; set; }
    }
}