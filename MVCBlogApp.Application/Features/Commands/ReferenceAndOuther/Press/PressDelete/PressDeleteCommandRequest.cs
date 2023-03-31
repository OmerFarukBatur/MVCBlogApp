using MediatR;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Press.PressDelete
{
    public class PressDeleteCommandRequest : IRequest<PressDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}