using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetByIdTKBiography
{
    public class GetByIdTKBiographyQueryHandler : IRequestHandler<GetByIdTKBiographyQueryRequest, GetByIdTKBiographyQueryResponse>
    {
        private readonly IYoneticiIslemleri _yoneticiIslemleri;

        public GetByIdTKBiographyQueryHandler(IYoneticiIslemleri yoneticiIslemleri)
        {
            _yoneticiIslemleri = yoneticiIslemleri;
        }

        public async Task<GetByIdTKBiographyQueryResponse> Handle(GetByIdTKBiographyQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _yoneticiIslemleri.GetByIdTKBiographyAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Languages = null,
                    Statuses = null,
                    TaylanK = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
