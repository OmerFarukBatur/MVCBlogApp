using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetByIdFixBMI
{
    public class GetByIdFixBMIQueryRequest : IRequest<GetByIdFixBMIQueryResponse>
    {
        public int Id { get; set; }
    }
}