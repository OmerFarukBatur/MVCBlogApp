using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Member.Contact.MemberContactCreate
{
    public class MemberContactCreateCommandRequest : IRequest<MemberContactCreateCommandResponse>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int ContactCategoryId { get; set; }
    }
}