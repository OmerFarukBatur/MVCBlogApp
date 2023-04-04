using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidDelete
{
    public class FixFeedPyramidDeleteCommandRequest : IRequest<FixFeedPyramidDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}