using MediatR;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamDelete
{
    public class OurTeamDeleteCommandRequest : IRequest<OurTeamDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}