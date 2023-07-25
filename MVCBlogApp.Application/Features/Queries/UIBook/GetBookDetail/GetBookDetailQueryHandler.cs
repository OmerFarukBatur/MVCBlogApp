using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIBook.GetBookDetail
{
    public class GetBookDetailQueryHandler : IRequestHandler<GetBookDetailQueryRequest, GetBookDetailQueryResponse>
    {
        private readonly IUIOtherService _service;

        public GetBookDetailQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<GetBookDetailQueryResponse> Handle(GetBookDetailQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.id != null)
            {
                return await _service.GetBookDetailAsync(request);
            }
            else
            {
                return new()
                {
                    Book = null
                };
            }
        }
    }
}
