using MediatR;

namespace MVCBlogApp.Application.Features.Commands.File.Image.ImageDelete
{
    public class ImageDeleteCommandRequest : IRequest<ImageDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}