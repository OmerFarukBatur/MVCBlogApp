using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetByIdUser
{
    public class GetByIdUserQueryResponse
    {
        public VM_Member? Member { get; set; }
        public List<VM_UserAuth>? UserAuths { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}