using MVCBlogApp.Application.Repositories.NewsPaper;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.NewsPaper
{
    public class NewsPaperReadRepository : ReadRepository<E.NewsPaper>, INewsPaperReadRepository
    {
        public NewsPaperReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
