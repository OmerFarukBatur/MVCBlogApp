using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetNewsPaperCreateItems
{
    public class GetNewsPaperCreateItemsQueryHandler : IRequestHandler<GetNewsPaperCreateItemsQueryRequest, GetNewsPaperCreateItemsQueryResponse>
    {
        private readonly INewsService _newsService;

        public GetNewsPaperCreateItemsQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<GetNewsPaperCreateItemsQueryResponse> Handle(GetNewsPaperCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _newsService.GetNewsPaperCreateItemsAsync();
        }
    }
}
