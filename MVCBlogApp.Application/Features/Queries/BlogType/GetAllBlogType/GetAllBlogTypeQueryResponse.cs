using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.BlogType.GetAllBlogType
{
    public class GetAllBlogTypeQueryResponse
    {
        public List<VM_BlogType> BlogTypes { get; set; }
    }
}