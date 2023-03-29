using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamCreate
{
    public class OurTeamCreateCommandRequest : IRequest<OurTeamCreateCommandResponse>
    {
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public IFormFileCollection FormFile { get; set; }
        public string Bio { get; set; }
        public int? CreateUserId { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}