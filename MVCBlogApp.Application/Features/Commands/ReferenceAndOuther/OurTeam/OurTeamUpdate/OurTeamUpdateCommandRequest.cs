using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamUpdate
{
    public class OurTeamUpdateCommandRequest : IRequest<OurTeamUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public IFormFileCollection? FormFile { get; set; }
        public string Bio { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}