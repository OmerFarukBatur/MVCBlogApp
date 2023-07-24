using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.YemekTarifleriPartialView
{
    public class YemekTarifleriPartialViewQueryHandler : IRequestHandler<YemekTarifleriPartialViewQueryRequest, YemekTarifleriPartialViewQueryResponse>
    {
        private readonly IUIOtherService _service;

        public YemekTarifleriPartialViewQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<YemekTarifleriPartialViewQueryResponse> Handle(YemekTarifleriPartialViewQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.YemekTarifleriPartialViewAsync(request);
        }
    }
}
