using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetAllWorkshopType
{
    public class GetAllWorkshopTypeQueryResponse
    {
        public List<VM_WorkshopType> WorkshopTypes { get; set; }
    }
}