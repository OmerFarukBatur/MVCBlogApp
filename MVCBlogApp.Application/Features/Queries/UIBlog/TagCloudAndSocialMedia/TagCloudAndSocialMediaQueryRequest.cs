using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.TagCloudAndSocialMedia
{
    public class TagCloudAndSocialMediaQueryRequest : IRequest<TagCloudAndSocialMediaQueryResponse>
    {
        public int id { get; set; }
    }
}