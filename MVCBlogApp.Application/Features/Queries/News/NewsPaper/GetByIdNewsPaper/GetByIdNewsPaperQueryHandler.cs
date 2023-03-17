using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetByIdNewsPaper
{
    public class GetByIdNewsPaperQueryHandler : IRequestHandler<GetByIdNewsPaperQueryRequest, GetByIdNewsPaperQueryResponse>
    {
        private readonly INewsService _newsService;

        public GetByIdNewsPaperQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<GetByIdNewsPaperQueryResponse> Handle(GetByIdNewsPaperQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _newsService.GetByIdNewsPaperAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Languages = null,
                    NewsPaper = null,
                    Statuses = null,
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
