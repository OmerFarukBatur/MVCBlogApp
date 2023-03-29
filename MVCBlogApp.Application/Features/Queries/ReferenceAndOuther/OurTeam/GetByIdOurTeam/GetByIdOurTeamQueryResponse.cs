using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetByIdOurTeam
{
    public class GetByIdOurTeamQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_OurTeam? OurTeam { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
    }
}