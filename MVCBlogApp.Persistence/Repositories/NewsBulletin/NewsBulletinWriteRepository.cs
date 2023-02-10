using MVCBlogApp.Application.Repositories.NewsBulletin;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.NewsBulletin
{
    public class NewsBulletinWriteRepository : WriteRepository<E.NewsBulletin>, INewsBulletinWriteRepository
    {
        public NewsBulletinWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
