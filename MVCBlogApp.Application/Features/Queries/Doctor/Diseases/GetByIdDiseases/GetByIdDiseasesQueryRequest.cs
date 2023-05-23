using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Diseases.GetByIdDiseases
{
    public class GetByIdDiseasesQueryRequest : IRequest<GetByIdDiseasesQueryResponse>
    {
        public int Id { get; set; }
    }
}