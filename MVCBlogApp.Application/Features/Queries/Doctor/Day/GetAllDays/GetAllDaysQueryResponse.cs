using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Day.GetAllDays
{
    public class GetAllDaysQueryResponse
    {
        public List<VM_Days> Days { get; set; }
    }
}