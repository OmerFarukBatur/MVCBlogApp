using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.IUWorkShop.GetWhereWorkShop
{
    public class GetWhereWorkShopQueryHandler : IRequestHandler<GetWhereWorkShopQueryRequest, GetWhereWorkShopQueryResponse>
    {
        private readonly IUIOtherService _service;

        public GetWhereWorkShopQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<GetWhereWorkShopQueryResponse> Handle(GetWhereWorkShopQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetWhereWorkShopAsync();
        }
    }
}
