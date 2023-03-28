using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetSeminarVisualsCreateItems
{
    public class GetSeminarVisualsCreateItemsQueryResponse
    {
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Statuses { get; set; }
    }
}