using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList
{
    public class AdminRoleListQueryResponse
    {
        public List<Auth> Auths { get; set; }         
    }
}