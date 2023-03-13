using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultBMIs.GetByIdResultBMI
{
    public class GetByIdResultBMIQueryRequest : IRequest<GetByIdResultBMIQueryResponse>
    {
        public int Id { get; set; }
    }
}