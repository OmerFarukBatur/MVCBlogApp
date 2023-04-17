using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetByIdWorkshopType
{
    public class GetByIdWorkshopTypeQueryResponse
    {
        public List<VM_Language>? Languages { get; set; }
        public VM_WorkshopType? WorkshopType { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}