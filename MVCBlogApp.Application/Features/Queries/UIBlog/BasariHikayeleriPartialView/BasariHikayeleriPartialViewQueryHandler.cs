using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.BasariHikayeleriPartialView
{
    public class BasariHikayeleriPartialViewQueryHandler : IRequestHandler<BasariHikayeleriPartialViewQueryRequest, BasariHikayeleriPartialViewQueryResponse>
    {
        private readonly IUIOtherService _service;

        public BasariHikayeleriPartialViewQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<BasariHikayeleriPartialViewQueryResponse> Handle(BasariHikayeleriPartialViewQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.BasariHikayeleriPartialViewAsync(request);
        }
    }
}
