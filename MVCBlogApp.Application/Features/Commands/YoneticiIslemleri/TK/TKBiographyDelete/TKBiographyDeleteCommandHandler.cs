using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyDelete
{
    public class TKBiographyDeleteCommandHandler : IRequestHandler<TKBiographyDeleteCommandRequest, TKBiographyDeleteCommandResponse>
    {
        private readonly IYoneticiIslemleri _yoneticiIslemleri;

        public TKBiographyDeleteCommandHandler(IYoneticiIslemleri yoneticiIslemleri)
        {
            _yoneticiIslemleri = yoneticiIslemleri;
        }

        public async Task<TKBiographyDeleteCommandResponse> Handle(TKBiographyDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _yoneticiIslemleri.TKBiographyDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
