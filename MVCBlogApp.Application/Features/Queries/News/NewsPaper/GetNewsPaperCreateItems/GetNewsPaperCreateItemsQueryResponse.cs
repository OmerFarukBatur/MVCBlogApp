using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetNewsPaperCreateItems
{
    public class GetNewsPaperCreateItemsQueryResponse
    {
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Statuses { get; set; }
    }
}