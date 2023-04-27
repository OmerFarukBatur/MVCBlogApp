using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryDelete
{
    public class ContactCategoryDeleteCommandRequest : IRequest<ContactCategoryDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}