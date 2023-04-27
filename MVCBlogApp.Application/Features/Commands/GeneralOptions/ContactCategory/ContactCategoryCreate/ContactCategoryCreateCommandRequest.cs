using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryCreate
{
    public class ContactCategoryCreateCommandRequest : IRequest<ContactCategoryCreateCommandResponse>
    {
        public string ContactCategoryName { get; set; }
        public int LangId { get; set; }
    }
}