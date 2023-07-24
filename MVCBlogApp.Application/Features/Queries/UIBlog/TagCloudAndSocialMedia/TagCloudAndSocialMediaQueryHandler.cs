using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.TagCloudAndSocialMedia
{
    public class TagCloudAndSocialMediaQueryHandler : IRequestHandler<TagCloudAndSocialMediaQueryRequest, TagCloudAndSocialMediaQueryResponse>
    {
        private readonly IUIOtherService _uIOtherService;

        public TagCloudAndSocialMediaQueryHandler(IUIOtherService uIOtherService)
        {
            _uIOtherService = uIOtherService;
        }

        public async Task<TagCloudAndSocialMediaQueryResponse> Handle(TagCloudAndSocialMediaQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uIOtherService.TagCloudAndSocialMediaAsync(request);
        }
    }
}
