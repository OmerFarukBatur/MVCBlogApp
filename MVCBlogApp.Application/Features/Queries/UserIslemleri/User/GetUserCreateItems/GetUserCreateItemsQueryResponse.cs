using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetUserCreateItems
{
    public class GetUserCreateItemsQueryResponse
    {
        public List<VM_UserAuth> UserAuths { get; set; }
    }
}