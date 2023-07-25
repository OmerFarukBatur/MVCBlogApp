using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIBook.GetBookDetail
{
    public class GetBookDetailQueryRequest : IRequest<GetBookDetailQueryResponse>
    {
        public string id { get; set; }
    }
}