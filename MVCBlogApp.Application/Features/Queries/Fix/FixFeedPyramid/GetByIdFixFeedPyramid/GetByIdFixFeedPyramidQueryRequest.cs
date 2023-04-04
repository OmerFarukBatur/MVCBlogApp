using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetByIdFixFeedPyramid
{
    public class GetByIdFixFeedPyramidQueryRequest : IRequest<GetByIdFixFeedPyramidQueryResponse>
    {
        public int Id { get; set; }
    }
}