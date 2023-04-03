using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhDelete
{
    public class FixBmhDeleteCommandRequest : IRequest<FixBmhDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}