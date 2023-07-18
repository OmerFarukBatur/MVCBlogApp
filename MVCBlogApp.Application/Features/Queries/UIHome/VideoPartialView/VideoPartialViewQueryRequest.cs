using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIHome.VideoPartialView
{
    public class VideoPartialViewQueryRequest : IRequest<VideoPartialViewQueryResponse>
    {
        public int page { get; set; } = 1;
    }
}