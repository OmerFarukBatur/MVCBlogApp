using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Day.GetByIdDay
{
    public class GetByIdDayQueryResponse
    {
        public VM_Days? Day { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}