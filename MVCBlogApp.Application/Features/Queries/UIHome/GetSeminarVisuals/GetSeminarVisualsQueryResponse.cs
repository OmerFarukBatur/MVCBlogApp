using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIHome.GetSeminarVisuals
{
    public class GetSeminarVisualsQueryResponse
    {
        public List<VM_SeminarVisuals> SeminarVisuals { get; set; }
    }
}