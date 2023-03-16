using MediatR;

namespace MVCBlogApp.Application.Features.Commands.File.Video.VideoCreate
{
    public class VideoCreateCommandRequest : IRequest<VideoCreateCommandResponse>
    {
        public int VideoCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string VideoEmbedCode { get; set; }
        public int? CreateUserId { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}