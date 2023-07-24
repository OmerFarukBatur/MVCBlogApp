using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.YemekTarifleriPartialView
{
    public class YemekTarifleriPartialViewQueryRequest : IRequest<YemekTarifleriPartialViewQueryResponse>
    {
        public int page { get; set; } = 1;
    }
}