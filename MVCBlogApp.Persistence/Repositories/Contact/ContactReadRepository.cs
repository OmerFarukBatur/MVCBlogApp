using MVCBlogApp.Application.Repositories.Contact;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Contact
{
    public class ContactReadRepository : ReadRepository<E.Contact>, IContactReadRepository
    {
        public ContactReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
