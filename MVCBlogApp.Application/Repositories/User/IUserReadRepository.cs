using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.User
{
    public interface IUserReadRepository : IReadRepository<E.User>
    {
    }
}
