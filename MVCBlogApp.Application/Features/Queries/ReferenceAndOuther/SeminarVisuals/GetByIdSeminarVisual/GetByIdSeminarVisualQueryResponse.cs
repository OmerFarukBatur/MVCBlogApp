using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetByIdSeminarVisual
{
    public class GetByIdSeminarVisualQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_SeminarVisuals? SeminarVisuals { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
    }
}