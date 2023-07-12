using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Commands.IUHome.UploadImage
{
    public class UploadImageCommandResponse
    {
        public VM_LocalUploadFile? LocalUploadFile { get; set; }
    }
}