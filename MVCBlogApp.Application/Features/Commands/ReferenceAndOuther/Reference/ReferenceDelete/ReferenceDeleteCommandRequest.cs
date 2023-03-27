using MediatR;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceDelete
{
    public class ReferenceDeleteCommandRequest : IRequest<ReferenceDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}