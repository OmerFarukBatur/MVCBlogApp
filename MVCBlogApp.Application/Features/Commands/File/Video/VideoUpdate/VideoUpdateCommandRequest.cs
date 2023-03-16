using MediatR;

namespace MVCBlogApp.Application.Features.Commands.File.Video.VideoUpdate
{
    public class VideoUpdateCommandRequest : IRequest<VideoUpdateCommandResponse>
    {
        public int Id { get; set; }
        public int VideoCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string VideoEmbedCode { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}