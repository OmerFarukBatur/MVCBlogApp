using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.BlogType.GetBlogTypeCreateItems
{
    public class GetBlogTypeCreateItemsQueryResponse
    {
        public List<VM_Language> Languages { get; set; }
    }
}