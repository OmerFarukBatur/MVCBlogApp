using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.PressType.GetByIdPressType
{
    public class GetByIdPressTypeQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_PressType? PressType { get; set; }
    }
}