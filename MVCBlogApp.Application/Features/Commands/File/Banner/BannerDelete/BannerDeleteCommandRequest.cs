using MediatR;

namespace MVCBlogApp.Application.Features.Commands.File.Banner.BannerDelete
{
    public class BannerDeleteCommandRequest : IRequest<BannerDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}