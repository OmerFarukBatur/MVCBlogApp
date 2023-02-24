using MediatR;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetByIdLanguage
{
    public class GetByIdLanguageQueryRequest : IRequest<GetByIdLanguageQueryResponse>
    {
        public int Id { get; set; }
    }
}