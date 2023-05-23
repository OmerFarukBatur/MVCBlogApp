using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesUpdate
{
    public class DiseasesUpdateCommandRequest : IRequest<DiseasesUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string DiseasesName { get; set; }
        public int Type { get; set; }
    }
}