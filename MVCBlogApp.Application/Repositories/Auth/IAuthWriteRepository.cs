using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Auth
{
    public interface IAuthWriteRepository : IWriteRepository<E.Auth>
    {
    }
}
