using MediatR;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeDelete
{
    public class PressTypeDeleteCommandRequest : IRequest<PressTypeDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}