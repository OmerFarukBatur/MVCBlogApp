using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.UIBlogPartialView
{
    public class UIBlogPartialViewQueryRequest : IRequest<UIBlogPartialViewQueryResponse>
    {
        public int page { get; set; } = 1;
    }
}