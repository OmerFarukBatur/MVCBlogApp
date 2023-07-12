using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.IUHome.UploadImage
{
    public class UploadImageCommandRequest : IRequest<UploadImageCommandResponse>
    {
        public IFormFileCollection? FormFile { get; set; }
    }
}