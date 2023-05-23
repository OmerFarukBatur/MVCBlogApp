using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesCreate
{
    public class DiseasesCreateCommandRequest : IRequest<DiseasesCreateCommandResponse>
    {
        public string DiseasesName { get; set; }
        public int Type { get; set; }
    }
}