using MediatR;

namespace MVCBlogApp.Application.Features.Queries.File.Video.GetByIdVideo
{
    public class GetByIdVideoQueryRequest : IRequest<GetByIdVideoQueryResponse>
    {
        public int Id { get; set; }
    }
}