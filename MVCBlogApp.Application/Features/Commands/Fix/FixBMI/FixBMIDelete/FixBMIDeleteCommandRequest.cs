using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMIDelete
{
    public class FixBMIDeleteCommandRequest : IRequest<FixBMIDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}