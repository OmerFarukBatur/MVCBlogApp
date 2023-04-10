using MediatR;

namespace MVCBlogApp.Application.Features.Queries.File.Banner.GetByIdBanner
{
    public class GetByIdBannerQueryRequest : IRequest<GetByIdBannerQueryResponse>
    {
        public int Id { get; set; }
    }
}