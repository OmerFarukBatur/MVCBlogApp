using MVCBlogApp.Application.Repositories.Contact;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Contact
{
    public class ContactWriteRepository : WriteRepository<E.Contact>, IContactWriteRepository
    {
        public ContactWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
