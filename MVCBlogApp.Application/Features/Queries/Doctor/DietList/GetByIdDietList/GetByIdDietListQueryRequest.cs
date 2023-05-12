using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetByIdDietList
{
    public class GetByIdDietListQueryRequest : IRequest<GetByIdDietListQueryResponse>
    {
        public int Id { get; set; }
    }
}