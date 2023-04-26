using MediatR;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerDelete
{
    public class InfluencerDeleteCommandRequest : IRequest<InfluencerDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}