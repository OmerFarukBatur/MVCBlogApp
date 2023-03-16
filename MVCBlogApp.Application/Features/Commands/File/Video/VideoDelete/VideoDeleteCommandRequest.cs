using MediatR;

namespace MVCBlogApp.Application.Features.Commands.File.Video.VideoDelete
{
    public class VideoDeleteCommandRequest : IRequest<VideoDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}