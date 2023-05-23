using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesDelete
{
    public class DiseasesDeleteCommandRequest : IRequest<DiseasesDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}