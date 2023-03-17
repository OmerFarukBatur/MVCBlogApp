using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetAllNewsPaper
{
    public class GetAllNewsPaperQueryHandler : IRequestHandler<GetAllNewsPaperQueryRequest, GetAllNewsPaperQueryResponse>
    {
        private readonly INewsService _newsService;

        public GetAllNewsPaperQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<GetAllNewsPaperQueryResponse> Handle(GetAllNewsPaperQueryRequest request, CancellationToken cancellationToken)
        {
            return await _newsService.GetAllNewsPaperAsync();
        }
    }
}
