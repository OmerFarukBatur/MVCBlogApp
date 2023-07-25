using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Contact.ContactCreate
{
    public class ContactCreateCommandRequest : IRequest<ContactCreateCommandResponse>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int ContactCategoryId { get; set; }
    }
}