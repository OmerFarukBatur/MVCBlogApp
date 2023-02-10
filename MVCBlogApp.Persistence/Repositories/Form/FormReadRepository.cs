using MVCBlogApp.Application.Repositories.Form;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Form
{
    public class FormReadRepository : ReadRepository<E.Form>, IFormReadRepository
    {
        public FormReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
