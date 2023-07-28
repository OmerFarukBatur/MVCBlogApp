using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.IUWorkShop.GetWorkshop
{
    public class GetWorkshopQueryHandler : IRequestHandler<GetWorkshopQueryRequest, GetWorkshopQueryResponse>
    {
        private readonly IUIOtherService _service;

        public GetWorkshopQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<GetWorkshopQueryResponse> Handle(GetWorkshopQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.WsEducationID > 0)
            {
                return await _service.GetWorkshopAsync(request);
            }
            return new()
            {
                Workshops = null
            };
        }
    }
}
