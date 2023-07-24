using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.BasariHikayeleriPartialView
{
    public class BasariHikayeleriPartialViewQueryRequest : IRequest<BasariHikayeleriPartialViewQueryResponse>
    {
        public int page { get; set; } = 1;
    }
}