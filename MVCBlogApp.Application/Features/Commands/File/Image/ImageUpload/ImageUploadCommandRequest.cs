using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.File.Image.ImageUpload
{
    public class ImageUploadCommandRequest : IRequest<ImageUploadCommandResponse>
    {
        public string Title { get; set; }
        public IFormFileCollection FormFile { get; set; }
        public bool IsCover { get; set; }
        public int? CreateUserId { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}