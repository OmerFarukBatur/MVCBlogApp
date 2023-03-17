using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetAllNewsBulletin
{
    public class GetAllNewsBulletinQueryHandler : IRequestHandler<GetAllNewsBulletinQueryRequest, GetAllNewsBulletinQueryResponse>
    {
        private readonly INewsService _newsService;

        public GetAllNewsBulletinQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<GetAllNewsBulletinQueryResponse> Handle(GetAllNewsBulletinQueryRequest request, CancellationToken cancellationToken)
        {
            return await _newsService.GetAllNewsBulletinAsync();
        }
    }
}
