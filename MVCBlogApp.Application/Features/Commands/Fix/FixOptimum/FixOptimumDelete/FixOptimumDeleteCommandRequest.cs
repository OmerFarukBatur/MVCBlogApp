using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixOptimum.FixOptimumDelete
{
    public class FixOptimumDeleteCommandRequest : IRequest<FixOptimumDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}