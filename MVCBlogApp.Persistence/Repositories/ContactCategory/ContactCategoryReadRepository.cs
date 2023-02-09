using MVCBlogApp.Application.Repositories.ContactCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ContactCategory
{
    public class ContactCategoryReadRepository : ReadRepository<E.ContactCategory>, IContactCategoryReadRepository
    {
        public ContactCategoryReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
