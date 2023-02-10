using MVCBlogApp.Application.Repositories.NewsBulletin;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.NewsBulletin
{
    public class NewsBulletinReadRepository : ReadRepository<E.NewsBulletin>, INewsBulletinReadRepository
    {
        public NewsBulletinReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
