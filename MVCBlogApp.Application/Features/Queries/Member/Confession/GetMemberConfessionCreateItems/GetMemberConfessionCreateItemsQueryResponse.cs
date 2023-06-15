using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Member.Confession.GetMemberConfessionCreateItems
{
    public class GetMemberConfessionCreateItemsQueryResponse
    {
        public VM_Member Member { get; set; }
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Statuses { get; set; }
    }
}