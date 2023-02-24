using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.GetByIdAdmin
{
    public class GetByIdAdminQueryResponse
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public int? AuthId { get; set; }
        public List<Auth>? Auths { get; set; }
        public string? Message { get; set; }
    }
}