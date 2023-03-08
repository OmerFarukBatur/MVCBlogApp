using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetByIdUser
{
    public class GetByIdUserQueryRequest : IRequest<GetByIdUserQueryResponse>
    {
        public int Id { get; set; }
    }
}