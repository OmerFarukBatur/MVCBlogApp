using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdDietList
{
    public class GetByIdDietListQueryRequest : IRequest<GetByIdDietListQueryResponse>
    {
        public int Id { get; set; }
    }
}