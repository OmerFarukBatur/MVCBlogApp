using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdDietList
{
    public class GetByIdDietListQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_DietList? DietList { get; set; }
        public List<VM__DaysMeal>? DaysMeals { get; set; }
    }
}