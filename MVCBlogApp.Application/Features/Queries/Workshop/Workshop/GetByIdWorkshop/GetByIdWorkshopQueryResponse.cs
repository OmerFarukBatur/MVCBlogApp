using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Workshop.Workshop.GetByIdWorkshop
{
    public class GetByIdWorkshopQueryResponse
    {
        public List<VM_WorkshopEducation>? WorkshopEducations { get; set; }
        public List<VM_WorkshopType>? WorkshopTypes { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_Navigation>? Navigations { get; set; }
        public VM_Workshop? Workshop { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}