using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIHome.GetBiography
{
    public class GetBiographyQueryRequest : IRequest<GetBiographyQueryResponse>
    {
    }
}