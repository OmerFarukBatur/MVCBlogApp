using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsUpdate
{
    public class SeminarVisualsUpdateCommandRequest : IRequest<SeminarVisualsUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFileCollection? FormFile { get; set; }
        public DateTime sCreateDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int LangId { get; set; }
        public int StatusId { get; set; }
    }
}