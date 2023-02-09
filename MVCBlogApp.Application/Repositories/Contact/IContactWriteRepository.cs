using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Contact
{
    public interface IContactWriteRepository : IWriteRepository<E.Contact>
    {
    }
}
