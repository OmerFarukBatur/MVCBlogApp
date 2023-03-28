using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetAllSeminarVisuals
{
    public class GetAllSeminarVisualsQueryResponse
    {
        public List<VM_SeminarVisuals> SeminarVisuals { get; set; }
    }
}