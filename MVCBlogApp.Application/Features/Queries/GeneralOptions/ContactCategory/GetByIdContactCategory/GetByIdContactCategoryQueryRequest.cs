using MediatR;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetByIdContactCategory
{
    public class GetByIdContactCategoryQueryRequest : IRequest<GetByIdContactCategoryQueryResponse>
    {
        public int Id { get; set; }
    }
}