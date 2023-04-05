using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesUpdate
{
    public class FixHeartDiseasesUpdateCommandRequest : IRequest<FixHeartDiseasesUpdateCommandResponse>
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFileCollection? FormFile { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}