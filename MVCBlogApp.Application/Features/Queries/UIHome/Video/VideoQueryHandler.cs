using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.Video
{
    public class VideoQueryHandler : IRequestHandler<VideoQueryRequest, VideoQueryResponse>
    {
        private readonly IUIHomeService _uiHomeService;

        public VideoQueryHandler(IUIHomeService uiHomeService)
        {
            _uiHomeService = uiHomeService;
        }

        public async Task<VideoQueryResponse> Handle(VideoQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uiHomeService.VideoAsync();
        }
    }
}
