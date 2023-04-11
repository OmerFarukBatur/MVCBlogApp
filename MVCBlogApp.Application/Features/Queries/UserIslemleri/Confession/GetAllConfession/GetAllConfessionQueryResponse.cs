using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetAllConfession
{
    public class GetAllConfessionQueryResponse
    {
        public List<VM_Confession> Confessions { get; set; }
    }
}