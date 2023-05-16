using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Lab.GetByIdLab
{
    public class GetByIdLabQueryRequest : IRequest<GetByIdLabQueryResponse>
    {
        public int Id { get; set; }
    }
}