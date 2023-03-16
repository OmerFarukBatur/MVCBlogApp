using MediatR;

namespace MVCBlogApp.Application.Features.Queries.File.Image.GetByIdImage
{
    public class GetByIdImageQueryRequest : IRequest<GetByIdImageQueryResponse>
    {
        public int Id { get; set; }
    }
}