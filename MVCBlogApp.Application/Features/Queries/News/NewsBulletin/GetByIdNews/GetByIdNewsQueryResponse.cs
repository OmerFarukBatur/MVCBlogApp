using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetByIdNews
{
    public class GetByIdNewsQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_NewsBulletin? NewsBulletin { get; set; }
        public List<AllStatus>? Statuses { get; set; }
    }
}