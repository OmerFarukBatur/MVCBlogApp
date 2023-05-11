using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetDietListCreateItems
{
    public class GetDietListCreateItemsQueryResponse
    {
        public List<VM_Days> Days { get; set; }
        public List<VM_Meal> Meals { get; set; }
        public List<VM_AppointmentDetail> AppointmentDetails { get; set; }
    }
}