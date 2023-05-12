using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetByIdDietList
{
    public class GetByIdDietListQueryResponse
    {
        public VM_DietList? DietList { get; set; }
        public VM__DaysMeal? DaysMeal { get; set; }
        public List<VM_Days>? Days { get; set; }
        public List<VM_Meal>? Meals { get; set; }
        public List<VM_AppointmentDetail>? AppointmentDetails { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}