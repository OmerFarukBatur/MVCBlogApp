using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Member.MemberInfo.GetByIdMemberInfo
{
    public class GetByIdMemberInfoQueryResponse
    {
        public VM_MemberAllDetailODataType? MemberAllDetail { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}