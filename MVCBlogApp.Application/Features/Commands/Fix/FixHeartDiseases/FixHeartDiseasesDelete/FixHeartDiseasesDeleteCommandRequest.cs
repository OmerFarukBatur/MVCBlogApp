using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesDelete
{
    public class FixHeartDiseasesDeleteCommandRequest : IRequest<FixHeartDiseasesDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}