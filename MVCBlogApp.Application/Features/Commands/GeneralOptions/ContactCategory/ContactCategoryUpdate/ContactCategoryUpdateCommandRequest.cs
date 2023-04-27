using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryUpdate
{
    public class ContactCategoryUpdateCommandRequest : IRequest<ContactCategoryUpdateCommandResponse>
    {
        public  int Id { get; set; }
        public string ContactCategoryName { get; set; }
        public int LangId { get; set; }
    }
}