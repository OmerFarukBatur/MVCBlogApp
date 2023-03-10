using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultBMhs.GetByIdResultBMhs
{
    public class GetByIdResultBMhsQueryRequest : IRequest<GetByIdResultBMhsQueryResponse>
    {
        public int Id { get; set; }
    }
}