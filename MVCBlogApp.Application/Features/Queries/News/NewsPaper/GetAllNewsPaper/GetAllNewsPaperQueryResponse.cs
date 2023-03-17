using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetAllNewsPaper
{
    public class GetAllNewsPaperQueryResponse
    {
        public List<VM_NewsPaper> NewsPapers { get; set; }
    }
}