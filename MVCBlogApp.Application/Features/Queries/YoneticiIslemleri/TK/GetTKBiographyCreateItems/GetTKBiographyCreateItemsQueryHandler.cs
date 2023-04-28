using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetTKBiographyCreateItems
{
    public class GetTKBiographyCreateItemsQueryHandler : IRequestHandler<GetTKBiographyCreateItemsQueryRequest, GetTKBiographyCreateItemsQueryResponse>
    {
        private readonly IYoneticiIslemleri _yoneticiIslemleri;

        public GetTKBiographyCreateItemsQueryHandler(IYoneticiIslemleri yoneticiIslemleri)
        {
            _yoneticiIslemleri = yoneticiIslemleri;
        }

        public async Task<GetTKBiographyCreateItemsQueryResponse> Handle(GetTKBiographyCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _yoneticiIslemleri.GetTKBiographyCreateItemsAsync();
        }
    }
}
