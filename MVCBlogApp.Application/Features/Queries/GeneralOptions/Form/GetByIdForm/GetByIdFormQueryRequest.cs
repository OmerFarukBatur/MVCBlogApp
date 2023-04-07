using MediatR;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetByIdForm
{
    public class GetByIdFormQueryRequest : IRequest<GetByIdFormQueryResponse>
    {
        public int Id { get; set; }
    }
}