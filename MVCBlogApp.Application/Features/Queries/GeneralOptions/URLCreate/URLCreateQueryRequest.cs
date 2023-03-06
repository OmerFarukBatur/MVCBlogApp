using MediatR;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.URLCreate
{
    public class URLCreateQueryRequest : IRequest<URLCreateQueryResponse>
    {
        public string Title { get; set; }
    }
}