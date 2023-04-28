using MediatR;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyDelete
{
    public class TKBiographyDeleteCommandRequest : IRequest<TKBiographyDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}