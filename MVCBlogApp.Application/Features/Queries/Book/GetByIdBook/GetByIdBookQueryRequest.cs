using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Book.GetByIdBook
{
    public class GetByIdBookQueryRequest : IRequest<GetByIdBookQueryResponse>
    {
        public int Id { get; set; }
    }
}