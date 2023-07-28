using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.IUWorkShop.WorkShopApplicationForm
{
    public class WorkShopApplicationFormQueryResponse
    {
        public List<VM_Gender>? Genders { get; set; }
        public List<VM_HearAboutUS>? HearAboutUs { get; set; }
        public List<VM_Case>? Cases { get; set; }
        public List<VM_WorkshopCategory>? WorkshopCategories { get; set; }
        public List<VM_WorkshopEducation>? WorkshopEducations { get; set; }
        public List<VM_Workshop>? Workshops { get; set; }

        public int workshopEducationID { get; set; }
        public int workshopCategoryID { get; set; }
    }
}