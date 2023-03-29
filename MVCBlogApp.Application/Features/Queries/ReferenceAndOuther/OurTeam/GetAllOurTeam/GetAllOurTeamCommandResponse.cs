using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetAllOurTeam
{
    public class GetAllOurTeamCommandResponse
    {
        public List<VM_OurTeam> OurTeams { get; set; }
    }
}