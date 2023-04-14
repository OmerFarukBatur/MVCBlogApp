using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberNutritionist.GetAllMemberNutritionist
{
    public class GetAllMemberNutritionistQueryResponse
    {
        public List<VM_MembersInformation> MembersInformations { get; set; }
    }
}