using MediatR;

namespace MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryUpdate
{
    public class VideoCategoryUpdateCommandRequest : IRequest<VideoCategoryUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string VideoCategoryName { get; set; }
        public int LangId { get; set; }
        public int StatusId { get; set; }
    }
}