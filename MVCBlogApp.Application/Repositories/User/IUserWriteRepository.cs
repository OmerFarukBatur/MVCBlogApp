using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.User
{
    public interface IUserWriteRepository : IWriteRepository<E.User>
    {
    }
}
