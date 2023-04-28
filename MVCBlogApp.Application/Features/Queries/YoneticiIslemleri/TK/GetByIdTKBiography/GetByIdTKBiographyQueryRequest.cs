using MediatR;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetByIdTKBiography
{
    public class GetByIdTKBiographyQueryRequest : IRequest<GetByIdTKBiographyQueryResponse>
    {
        public int Id { get; set; }
    }
}