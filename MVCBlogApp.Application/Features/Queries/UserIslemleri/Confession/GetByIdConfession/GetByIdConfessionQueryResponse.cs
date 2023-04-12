using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetByIdConfession
{
    public class GetByIdConfessionQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_Confession? Confession { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
    }
}