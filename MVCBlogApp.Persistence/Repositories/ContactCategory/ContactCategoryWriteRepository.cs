using MVCBlogApp.Application.Repositories.ContactCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ContactCategory
{
    public class ContactCategoryWriteRepository : WriteRepository<E.ContactCategory>, IContactCategoryWriteRepository
    {
        public ContactCategoryWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
