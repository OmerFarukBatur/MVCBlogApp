using MediatR;

namespace MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryDelete
{
    public class VideoCategoryDeleteCommandRequest : IRequest<VideoCategoryDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}