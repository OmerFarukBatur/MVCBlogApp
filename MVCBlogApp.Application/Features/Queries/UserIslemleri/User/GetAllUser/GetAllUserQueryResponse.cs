using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public List<VM_Member> Members { get; set; }
    }
}