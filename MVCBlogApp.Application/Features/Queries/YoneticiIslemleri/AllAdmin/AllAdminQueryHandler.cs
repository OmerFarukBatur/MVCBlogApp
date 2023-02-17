using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AllAdmin
{
    public class AllAdminQueryHandler : IRequestHandler<AllAdminQueryRequest, AllAdminQueryResponse>
    {
        private readonly IYoneticiIslemleri _yoneticiIslemleri;

        public AllAdminQueryHandler(IYoneticiIslemleri yoneticiIslemleri)
        {
            _yoneticiIslemleri = yoneticiIslemleri;
        }

        public async Task<AllAdminQueryResponse> Handle(AllAdminQueryRequest request, CancellationToken cancellationToken)
        {
            return await _yoneticiIslemleri.AllAdminAsync();
        }
    }
}
