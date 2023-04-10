using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.File.Banner.BannerUpdate
{
    public class BannerUpdateQueryRequest : IRequest<BannerUpdateQueryResponse>
    {
        public int Id { get; set; }
        public string BannerName { get; set; }
        public string BannerUrl { get; set; }
        public int BannerOrder { get; set; }
        public IFormFileCollection? FormFile { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}