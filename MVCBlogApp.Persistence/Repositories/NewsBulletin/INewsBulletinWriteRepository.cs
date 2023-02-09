using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.NewsBulletin
{
    public interface INewsBulletinWriteRepository : IWriteRepository<E.NewsBulletin>
    {
    }
}
