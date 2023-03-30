using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.PressType.GetAllPressType
{
    public class GetAllPressTypeQueryResponse
    {
        public List<VM_PressType> PressTypes { get; set; }
    }
}