using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesCreate
{
    public class FixHeartDiseasesCreateCommandRequest : IRequest<FixHeartDiseasesCreateCommandResponse>
    {
        public int FormId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFileCollection FormFile { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}