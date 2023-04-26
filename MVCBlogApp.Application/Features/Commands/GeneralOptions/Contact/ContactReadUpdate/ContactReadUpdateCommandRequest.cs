using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Contact.ContactReadUpdate
{
    public class ContactReadUpdateCommandRequest : IRequest<ContactReadUpdateCommandResponse>
    {
        public int Id { get; set; }
    }
}