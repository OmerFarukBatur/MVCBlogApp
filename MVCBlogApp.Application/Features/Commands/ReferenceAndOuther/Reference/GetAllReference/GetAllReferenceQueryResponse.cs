using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.GetAllReference
{
    public class GetAllReferenceQueryResponse
    {
        public List<VM_References> References { get; set; }
    }
}