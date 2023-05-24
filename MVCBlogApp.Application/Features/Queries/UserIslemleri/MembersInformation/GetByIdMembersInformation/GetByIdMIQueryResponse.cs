using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MembersInformation.GetByIdMembersInformation
{
    public class GetByIdMIQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_MemberAllDetail? MemberAllDetail { get; set; }
    }
}