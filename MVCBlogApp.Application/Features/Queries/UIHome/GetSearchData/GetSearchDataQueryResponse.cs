using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIHome.GetSearchData
{
    public class GetSearchDataQueryResponse
    {
        public List<VM_Search> Searches { get; set; }
    }
}