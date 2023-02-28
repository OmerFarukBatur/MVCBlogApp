using MediatR;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetByIdNavigation
{
    public class GetByIdNavigationQueryRequest : IRequest<GetByIdNavigationQueryResponse>
    {
        public int Id { get; set; }
    }
}