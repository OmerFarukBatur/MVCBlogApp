using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixPulse.FixPulseDelete
{
    public class FixPulseDeleteCommandRequest : IRequest<FixPulseDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}