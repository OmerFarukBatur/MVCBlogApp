using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetAllWorkshopEducation
{
    public class GetAllWorkshopEducationQueryResponse
    {
        public List<VM_WorkshopEducation> WorkshopEducations { get; set; }
    }
}