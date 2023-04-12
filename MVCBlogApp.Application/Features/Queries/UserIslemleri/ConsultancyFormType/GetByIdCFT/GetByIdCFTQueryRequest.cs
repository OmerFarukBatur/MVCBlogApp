using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyFormType.GetByIdCFT
{
    public class GetByIdCFTQueryRequest : IRequest<GetByIdCFTQueryResponse>
    {
        public int Id { get; set; }
    }
}