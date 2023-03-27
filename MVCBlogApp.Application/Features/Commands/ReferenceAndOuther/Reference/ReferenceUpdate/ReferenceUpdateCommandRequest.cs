using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceUpdate
{
    public class ReferenceUpdateCommandRequest : IRequest<ReferenceUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlLink { get; set; }
        public IFormFileCollection? FormFile { get; set; }
        public int StatusId { get; set; }
    }
}