using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetByIdNews
{
    public class GetByIdNewsQueryHandler : IRequestHandler<GetByIdNewsQueryRequest, GetByIdNewsQueryResponse>
    {
        private readonly INewsService _newsService;

        public GetByIdNewsQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<GetByIdNewsQueryResponse> Handle(GetByIdNewsQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _newsService.GetByIdNewsAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Statuses = null,
                    NewsBulletin = null,
                    State = false,
                    Message = "Lütfen geçerli değerler giriniz."
                };
            }
        }
    }
}
