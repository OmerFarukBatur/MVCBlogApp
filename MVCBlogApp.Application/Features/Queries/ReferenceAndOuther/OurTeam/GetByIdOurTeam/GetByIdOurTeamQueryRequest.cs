using MediatR;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetByIdOurTeam
{
    public class GetByIdOurTeamQueryRequest : IRequest<GetByIdOurTeamQueryResponse>
    {
        public int Id { get; set; }
    }
}