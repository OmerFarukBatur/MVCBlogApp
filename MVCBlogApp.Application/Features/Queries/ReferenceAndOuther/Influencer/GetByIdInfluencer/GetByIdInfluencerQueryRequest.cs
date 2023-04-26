using MediatR;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Influencer.GetByIdInfluencer
{
    public class GetByIdInfluencerQueryRequest : IRequest<GetByIdInfluencerQueryResponse>
    {
        public int Id { get; set; }
    }
}