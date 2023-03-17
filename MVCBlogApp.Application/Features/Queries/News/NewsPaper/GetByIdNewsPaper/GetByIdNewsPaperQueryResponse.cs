using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetByIdNewsPaper
{
    public class GetByIdNewsPaperQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_NewsPaper? NewsPaper { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }

    }
}