using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetByIdFixHeartDiseases
{
    public class GetByIdFixHeartDiseasesQueryRequest : IRequest<GetByIdFixHeartDiseasesQueryResponse>
    {
        public int Id { get; set; }
    }
}