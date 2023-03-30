using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetAllPress
{
    public class GetAllPressQueryResponse
    {
        public List<VM_Press> Presses { get; set; }
    }
}