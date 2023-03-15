using MediatR;

namespace MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryCreate
{
    public class VideoCategoryCreateCommandRequest : IRequest<VideoCategoryCreateCommandResponse>
    {
        public string VideoCategoryName { get; set; }
        public int LangId { get; set; }
        public int StatusId { get; set; }
    }
}