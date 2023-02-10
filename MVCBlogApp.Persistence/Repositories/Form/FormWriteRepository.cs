using MVCBlogApp.Application.Repositories.Form;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Form
{
    public class FormWriteRepository : WriteRepository<E.Form>, IFormWriteRepository
    {
        public FormWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
