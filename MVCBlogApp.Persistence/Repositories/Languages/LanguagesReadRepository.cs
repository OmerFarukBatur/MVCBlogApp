using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Languages
{
    public class LanguagesReadRepository : ReadRepository<E.Languages>, ILanguagesReadRepository
    {
        public LanguagesReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
