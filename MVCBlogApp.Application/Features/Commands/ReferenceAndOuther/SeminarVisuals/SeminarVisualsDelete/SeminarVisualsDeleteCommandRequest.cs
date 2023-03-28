using MediatR;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsDelete
{
    public class SeminarVisualsDeleteCommandRequest : IRequest<SeminarVisualsDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}