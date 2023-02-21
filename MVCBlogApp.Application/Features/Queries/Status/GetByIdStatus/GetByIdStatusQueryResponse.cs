using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Status.GetByIdStatus
{
    public class GetByIdStatusQueryResponse
    {
        public AllStatus? Status { get; set; }
        public bool State { get; set; }
    }
}