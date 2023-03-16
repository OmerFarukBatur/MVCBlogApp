using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.File.Image.ImageUpdate
{
    public class ImageUpdateCommandRequest : IRequest<ImageUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFileCollection? FormFile { get; set; }
        public bool IsCover { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}