using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.VideoPartialView
{
    public class VideoPartialViewQueryHandler : IRequestHandler<VideoPartialViewQueryRequest, VideoPartialViewQueryResponse>
    {
        private readonly IUIHomeService _homeService;

        public VideoPartialViewQueryHandler(IUIHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<VideoPartialViewQueryResponse> Handle(VideoPartialViewQueryRequest request, CancellationToken cancellationToken)
        {
            return await _homeService.VideoPartialViewAsync(request);
        }
    }
}
