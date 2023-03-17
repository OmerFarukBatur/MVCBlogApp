using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetNewsBulletinCreateItem
{
    public class GetNewsBulletinCreateItemQueryHandler : IRequestHandler<GetNewsBulletinCreateItemQueryRequest, GetNewsBulletinCreateItemQueryResponse>
    {
        private readonly INewsService _newsService;

        public GetNewsBulletinCreateItemQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<GetNewsBulletinCreateItemQueryResponse> Handle(GetNewsBulletinCreateItemQueryRequest request, CancellationToken cancellationToken)
        {
            return await _newsService.GetNewsBulletinCreateItemAsync();
        }
    }
}
