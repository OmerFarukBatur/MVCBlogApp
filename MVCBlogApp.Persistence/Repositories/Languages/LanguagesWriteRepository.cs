using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Languages
{
    public class LanguagesWriteRepository : WriteRepository<E.Languages>, ILanguagesWriteRepository
    {
        public LanguagesWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
