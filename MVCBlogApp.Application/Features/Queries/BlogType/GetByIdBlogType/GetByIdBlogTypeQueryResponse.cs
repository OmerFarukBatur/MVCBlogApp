using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.BlogType.GetByIdBlogType
{
    public class GetByIdBlogTypeQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_BlogType? BlogType { get; set; }
    }
}