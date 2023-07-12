using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIHome.GetPage
{
    public class GetPageQueryRequest : IRequest<GetPageQueryResponse>
    {
        public string id { get; set; }
        //public int LandID { get; set; }
    }
}