using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Member.GetByIdMemberInfo
{
    public class GetByIdMemberInfoQueryResponse
    {
        public VM_MemberAllDetail? MemberAllDetail { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}