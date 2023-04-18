using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetByIdWorkshopEducation
{
    public class GetByIdWorkshopEducationQueryResponse
    {
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_WorkshopCategory>? WorkshopCategories { get; set; }
        public VM_WorkshopEducation? WorkshopEducation { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}