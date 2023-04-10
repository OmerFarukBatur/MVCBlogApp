using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.File.Banner.BannerCreate
{
    public class BannerCreateCommandRequest : IRequest<BannerCreateCommandResponse>
    {
        public string BannerName { get; set; }
        public string BannerUrl { get; set; }
        public int BannerOrder { get; set; }
        public IFormFileCollection FormFile { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}