using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.UIBlogPartialView
{
    public class UIBlogPartialViewQueryHandler : IRequestHandler<UIBlogPartialViewQueryRequest, UIBlogPartialViewQueryResponse>
    {
        private readonly IUIOtherService _service;

        public UIBlogPartialViewQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<UIBlogPartialViewQueryResponse> Handle(UIBlogPartialViewQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.UIBlogPartialViewAsync(request);
        }
    }
}
