using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIHome.ConfessionsPartialView
{
    public class ConfessionsPartialViewQueryRequest : IRequest<ConfessionsPartialViewQueryResponse>
    {
        public int page { get; set; } = 1;
    }
}