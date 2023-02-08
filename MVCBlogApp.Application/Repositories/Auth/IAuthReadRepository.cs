using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Auth
{
    public interface IAuthReadRepository : IReadRepository<E.Auth>
    {
    }
}
