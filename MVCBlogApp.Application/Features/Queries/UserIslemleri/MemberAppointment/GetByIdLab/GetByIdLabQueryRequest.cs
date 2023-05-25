using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdLab
{
    public class GetByIdLabQueryRequest : IRequest<GetByIdLabQueryResponse>
    {
        public int Id { get; set; }
    }
}