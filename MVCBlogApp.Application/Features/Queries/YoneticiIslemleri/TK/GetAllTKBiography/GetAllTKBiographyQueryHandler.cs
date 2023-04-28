using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetAllTKBiography
{
    public class GetAllTKBiographyQueryHandler : IRequestHandler<GetAllTKBiographyQueryRequest, GetAllTKBiographyQueryResponse>
    {
        private readonly IYoneticiIslemleri _yoneticiIslemleri;

        public GetAllTKBiographyQueryHandler(IYoneticiIslemleri yoneticiIslemleri)
        {
            _yoneticiIslemleri = yoneticiIslemleri;
        }

        public async Task<GetAllTKBiographyQueryResponse> Handle(GetAllTKBiographyQueryRequest request, CancellationToken cancellationToken)
        {
            return await _yoneticiIslemleri.GetAllTKBiographyAsync();
        }
    }
}
